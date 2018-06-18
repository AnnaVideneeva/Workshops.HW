using Bogus;
using Rocket.DAL.Common.DbModels.ReleaseList;
using System.Collections.Generic;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о музыкальных жанрах,
    /// в моделях хранения данных
    /// </summary>
    public class FakeDbMusicGenreData
    {
        /// <summary>
        /// Возвращает генератор данных о музыкальных жанрах
        /// </summary>
        public Faker<DbMusicGenre> MusicGenreFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных музыкальных жанров
        /// </summary>
        public List<DbMusicGenre> MusicGenres { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о музыкальных жанрах
        /// </summary>
        /// <param name="genresCount">Необходимое количество сгенерированных музыкальных жанров</param>
        public FakeDbMusicGenreData(int genresCount)
        {
            MusicGenreFaker = new Faker<DbMusicGenre>()
                .RuleFor(g => g.Id, f => f.IndexFaker)
                .RuleFor(g => g.Name, f => f.Random.Word());

            MusicGenres = MusicGenreFaker.Generate(genresCount);
        }
    }
}