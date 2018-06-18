using Bogus;
using Rocket.DAL.Common.DbModels.ReleaseList;
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о жанрах видео,
    /// в моделях хранения данных
    /// </summary>
    public class FakeGenreEntities
    {
        /// <summary>
        /// Возвращает генератор данных о жанрах видео
        /// </summary>
        public Faker<GenreEntity> GenreFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных жанров видео
        /// </summary>
        public List<GenreEntity> GenreEntities { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о жанрах видео
        /// </summary>
        /// <param name="genresCount">Необходимое количество сгенерированных жанров видео</param>
        public FakeGenreEntities(int genresCount, FakeCategoryEntities categoryEntities)
        {
            GenreFaker = new Faker<GenreEntity>("ru")
                .RuleFor(g => g.Id, f => (short)f.IndexFaker)
                .RuleFor(g => g.Name, f => f.Random.Word())
                .RuleFor(g => g.Category, f => f.PickRandom(categoryEntities.CategoryEntities))
                .RuleFor(g => g.ListTvSerias, () => new List<TvSeriasEntity>());

            GenreEntities = GenreFaker.Generate(genresCount);

            foreach (var genreEntity in GenreEntities)
            {
                genreEntity.CategoryCode = genreEntity.Category.Code;
                genreEntity.Category.ListGenre.Add(genreEntity);
            }
        }
    }
}