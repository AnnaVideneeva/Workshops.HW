using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о музыке,
    /// в моделях домена
    /// </summary>
    public class FakeMusicData
    {
        /// <summary>
        /// Возвращает набор сгенерированных данных о музыкальных треках
        /// </summary>
        public FakeMusicTrackData FakeDbMusicTracksData { get; }

        /// <summary>
        /// Возвращает генератор данных о музыкантах
        /// </summary>
        public Faker<Musician> MusicianFaker { get; }

        /// <summary>
        /// Возвращает генератор данных о музыкальных жанрах
        /// </summary>
        public Faker<MusicGenre> MusicGenreFaker { get; }

        /// <summary>
        /// Возвращает генератор данных о музыкальных релизах
        /// </summary>
        public Faker<Music> MusicFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных музыкантов
        /// </summary>
        public List<Musician> Musician { get; }


        /// <summary>
        /// Возвращает коллекцию сгенерированных музыкальных жанров
        /// </summary>
        public List<MusicGenre> MusicGenre { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных музыкальных релизов
        /// </summary>
        public List<Music> Music { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о музыкальных релизах
        /// </summary>
        /// <param name="musicianCount">Необходимое количество сгенерированных музыкантов</param>
        /// <param name="genresCount">Необходимое количество сгенерированных музыкальных жанров</param>
        /// <param name="musicCount">Необходимое количество сгенерированных музыкальных релизов</param>
        public FakeMusicData(int musicianCount, int genresCount, int musicCount)
        {
            var fakeMusicianData = new FakeMusicianData(musicianCount);
            MusicianFaker = fakeMusicianData.MusicianFaker;
            Musician = fakeMusicianData.Persons;

            FakeDbMusicTracksData = new FakeMusicTrackData();

            var fakeMusicGenresData = new FakeMusicGenreData(genresCount);
            MusicGenreFaker = fakeMusicGenresData.MusicGenreFaker;
            MusicGenre = fakeMusicGenresData.MusicGenres;

            MusicFaker = new Faker<Music>()
                .RuleFor(m => m.Id, f => f.IndexFaker)
                .RuleFor(m => m.Title, f => string.Join(" ", f.Lorem.Words(2)))
                .RuleFor(m => m.ReleaseDate,
                    f => f.Date.Between(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(10)))
                .RuleFor(m => m.Genres, f => f.PickRandom(MusicGenre, f.Random.Number(1, 2)).ToList())
                .RuleFor(m => m.Musicians, f => f.PickRandom(Musician, f.Random.Number(1, 2)).ToList())
                .RuleFor(m => m.Duration, f => TimeSpan.FromSeconds(f.Random.Number(120, 3600)))
                .RuleFor(m => m.MusicTracks, f => FakeDbMusicTracksData.Generate(f.Random.Number(1, 13)));

            Music = MusicFaker.Generate(musicCount);
        }
    }
}