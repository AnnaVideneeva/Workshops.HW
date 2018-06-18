using Bogus;
using Rocket.DAL.Common.DbModels.Parser;
using System;
using System.Collections.Generic;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о сериях,
    /// в моделях хранения данных
    /// </summary>
    public class FakeEpisodeEntities
    {
        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о сериях
        /// </summary>
        public FakeEpisodeEntities()
        {
            var loremRu = new Bogus.DataSets.Lorem("ru");
            EpisodeFaker = new Faker<EpisodeEntity>()
                .RuleFor(m => m.Id, f => f.IndexFaker)
                .RuleFor(m => m.TitleRu, f => string.Join(" ", loremRu.Words(2)))
                .RuleFor(m => m.TitleEn, f => string.Join(" ", f.Lorem.Words(2)))
                .RuleFor(m => m.DurationInMinutes, f => f.Random.Double(15, 60))
                .RuleFor(m => m.UrlForEpisodeSource, f => f.Internet.Url());

            EpisodeEntities = new List<EpisodeEntity>();
        }

        /// <summary>
        /// Возвращает генератор данных о сериях
        /// </summary>
        public Faker<EpisodeEntity> EpisodeFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных серий
        /// </summary>
        public List<EpisodeEntity> EpisodeEntities { get; }

        /// <summary>
        /// Генерирует и возвращает коллекцию серий в заданном количестве
        /// начиная с заданного номера серии
        /// </summary>
        /// <param name="count">Количество серий</param>
        /// <param name="startEpisodeNumber">Начальный номер серии</param>
        /// <returns>Коллекция серий</returns>
        public List<EpisodeEntity> Generate(
            int count,
            DateTime startDate,
            int startEpisodeNumber = 1)
        {
            EpisodeFaker
                .RuleFor(m => m.ReleaseDateEn, startDate = startDate.AddDays(5))
                .RuleFor(m => m.ReleaseDateRu, startDate = startDate.AddDays(2))
                .RuleFor(m => m.Number, startEpisodeNumber++);

            var episodes = EpisodeFaker.Generate(count);
            EpisodeEntities.AddRange(episodes);
            return episodes;
        }
    }
}