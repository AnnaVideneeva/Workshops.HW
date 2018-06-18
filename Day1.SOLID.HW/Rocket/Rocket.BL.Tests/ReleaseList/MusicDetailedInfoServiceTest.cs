using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Rocket.BL.Services.ReleaseList;
using Rocket.BL.Tests.ReleaseList.FakeData;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.UoW;
using System;
using System.Linq;
using System.Linq.Expressions;
using Rocket.DAL.Common.Repositories;

namespace Rocket.BL.Tests.ReleaseList
{
    /// <summary>
    /// Unit-тесты для сервиса <see cref="MusicDetailedInfoService"/>
    /// </summary>
    [TestFixture]
    public class MusicDetailedInfoServiceTest
    {
        private const int MusicCount = 300;
        private MusicDetailedInfoService _musicDetailedInfoService;
        private FakeDbMusicData _fakeDbMusicData;

        /// <summary>
        /// Осуществляет все необходимые настройки для тестов.
        /// AutoMapper, Bogus (FakeDbMusicData), Moq
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddProfiles("Rocket.BL.Common"); });

            _fakeDbMusicData = new FakeDbMusicData(100, 10, MusicCount);

            var mockDbMusicRepository = new Mock<IBaseRepository<DbMusic>>();
            mockDbMusicRepository
                .Setup(mock => mock.Get(It.IsAny<Expression<Func<DbMusic, bool>>>(), null, It.IsAny<string>()))
                .Returns((Expression<Func<DbMusic, bool>> filter,
                    Func<IQueryable<DbMusic>, IOrderedQueryable<DbMusic>> orderBy,
                    string includeProperties) => _fakeDbMusicData.Music.Where(filter.Compile()));
            mockDbMusicRepository.Setup(mock => mock.GetById(It.IsAny<int>()))
                .Returns((int id) => _fakeDbMusicData.Music.Find(f => f.Id == id));
            mockDbMusicRepository.Setup(mock => mock.Insert(It.IsAny<DbMusic>()))
                .Callback((DbMusic f) => _fakeDbMusicData.Music.Add(f));
            mockDbMusicRepository.Setup(mock => mock.Update(It.IsAny<DbMusic>()))
                .Callback((DbMusic f) => _fakeDbMusicData.Music.Find(d => d.Id == f.Id).Title = f.Title);
            mockDbMusicRepository.Setup(mock => mock.Delete(It.IsAny<int>()))
                .Callback((int id) => _fakeDbMusicData.Music
                    .Remove(_fakeDbMusicData.Music.Find(f => f.Id == id)));

            var mockDbMusicUnitOfWork = new Mock<IUnitOfWork>();
            mockDbMusicUnitOfWork.Setup(mock => mock.MusicRepository)
                .Returns(() => mockDbMusicRepository.Object); //todo - закоментил, не знаю в чем дело

            _musicDetailedInfoService = new MusicDetailedInfoService(mockDbMusicUnitOfWork.Object);
        }

        /// <summary>
        /// Тест метода получения экземпляра музыкального релиза по заданному идентификатору.
        /// Музыкальный релиз с передаваемым идентификатором существует
        /// </summary>
        /// <param name="id">Идентификатор музыкального релиза</param>
        [Test, Order(1)]
        public void GetExistedMusicTest([Random(0, MusicCount - 1, 5)] int id)
        {
            var expectedMusic = _fakeDbMusicData.Music.Find(f => f.Id == id);

            var actualMusic = _musicDetailedInfoService.GetMusic(id);

            actualMusic.Should().BeEquivalentTo(expectedMusic,
                options => options.ExcludingMissingMembers().Excluding(mus => mus.Duration));
            actualMusic.Musicians.Should().BeEquivalentTo(expectedMusic.Musicians,
                options => options.ExcludingMissingMembers());
            actualMusic.Genres.Should().BeEquivalentTo(expectedMusic.Genres,
                options => options.ExcludingMissingMembers());
        }

        /// <summary>
        /// Тест метода получения экземпляра музыкального релиза по заданному идентификатору.
        /// Музыкальный релиз с передаваемым идентификатором не существует
        /// </summary>
        /// <param name="id">Идентификатор музыкального релиза</param>
        [Test, Order(1)]
        public void GetNotExistedMusicTest([Random(MusicCount, MusicCount + 300, 5)]
            int id)
        {
            var actualMusic = _musicDetailedInfoService.GetMusic(id);

            actualMusic.Should().BeNull();
        }


        /// <summary>
        /// Тест метода добавления музыкального релиза в хранилище данных
        /// </summary>
        [Test, Repeat(5), Order(2)]
        public void AddMusicTest()
        {
            var music = new FakeMusicData(5, 2, 15).MusicFaker.Generate();
            music.Id = _fakeDbMusicData.Music.Last().Id + 1;

            var actualId = _musicDetailedInfoService.AddMusic(music);
            var actualMusic = _musicDetailedInfoService.GetMusic(actualId);

            actualMusic.Should().BeEquivalentTo(music);
        }

        /// <summary>
        /// Тест метода обновления данных о музыкальном релизе
        /// </summary>
        /// <param name="id">Идентификатор музыкального релиза для обновления</param>
        [Test, Order(2)]
        public void UpdateMusicTest([Random(0, MusicCount - 1, 5)] int id)
        {
            var music = _musicDetailedInfoService.GetMusic(id);
            music.Title = new Bogus.Faker().Lorem.Word();

            _musicDetailedInfoService.UpdateMusic(music);
            var actualMusic = _fakeDbMusicData.Music.Find(f => f.Id == id);

            actualMusic.Title.Should().Be(music.Title);
        }

        /// <summary>
        /// Тест метода удаления музыкального релиза из хранилища данных
        /// </summary>
        /// <param name="id">Идентификатор музыкального релиза для удаления</param>
        [Test, Order(3)]
        public void DeleteMusicTest([Random(0, MusicCount - 1, 5)] int id)
        {
            _musicDetailedInfoService.DeleteMusic(id);

            var actualMusic = _fakeDbMusicData.Music.Find(music => music.Id == id);

            actualMusic.Should().BeNull();
        }

        /// <summary>
        /// Тест метода проверки наличия музыкального релиза в хранилище данных.
        /// Музыкальный релиз существует
        /// </summary>
        /// <param name="id">Идентификатор музыкального релиза для поиска</param>
        [Test, Order(2)]
        public void MusicExistsTest([Random(0, MusicCount - 1, 5)] int id)
        {
            var titleToFind = _fakeDbMusicData.Music.Find(tv => tv.Id == id).Title;

            var actual = _musicDetailedInfoService
                .MusicExists(tv => tv.Title == titleToFind);

            actual.Should().BeTrue();
        }

        /// <summary>
        /// Тест метода проверки наличия музыкального релиза в хранилище данных.
        /// Музыкальный релиз не существует
        /// </summary>
        /// <param name="title">Название музыкального релиза для поиска</param>
        [Test, Order(2)]
        public void MusicNotExistsTest([Values("1 1 1", "2 22 2", "", "4 word 4", "three words title")]
            string title)
        {
            var actual = _musicDetailedInfoService
                .MusicExists(tv => tv.Title == title);

            actual.Should().BeFalse();
        }
    }
}