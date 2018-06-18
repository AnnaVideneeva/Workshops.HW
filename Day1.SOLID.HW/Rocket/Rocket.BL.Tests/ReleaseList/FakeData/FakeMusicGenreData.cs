using System.Collections.Generic;
using Bogus;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о музыкальных жанрах,
    /// в моделях домена
    /// </summary>
    public class FakeMusicGenreData
    {
        /// <summary>
        /// Возвращает генератор данных о музыкальных жанрах
        /// </summary>
        public Faker<MusicGenre> MusicGenreFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных музыкальных жанров
        /// </summary>
        public List<MusicGenre> MusicGenres { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о музыкальных жанрах
        /// </summary>
        /// <param name="genresCount">Необходимое количество сгенерированных музыкальных жанров</param>
        public FakeMusicGenreData(int genresCount)
        {
            MusicGenreFaker = new Faker<MusicGenre>()
                .RuleFor(g => g.Id, f => f.IndexFaker)
                .RuleFor(g => g.Name, f => f.Random.Word());

            MusicGenres = MusicGenreFaker.Generate(genresCount);
        }
    }
}