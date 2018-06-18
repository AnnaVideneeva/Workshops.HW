using System;
using Bogus;
using Rocket.DAL.Common.DbModels.Parser;
using System.Collections.Generic;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о сезонах,
    /// в моделях хранения данных
    /// </summary>
    public class FakeSeasonEntities
    {
        /// <summary>
        /// Возвращает генератор данных о сезонах
        /// </summary>
        public Faker<SeasonEntity> SeasonFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных сезонов
        /// </summary>
        public List<SeasonEntity> SeasonEntities { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о сезонах
        /// </summary>
        public FakeSeasonEntities()
        {
            SeasonFaker = new Faker<SeasonEntity>()
                .RuleFor(m => m.Id, f => f.IndexFaker)
                .RuleFor(m => m.PosterImageUrl, f => f.Internet.Url());

            SeasonEntities = new List<SeasonEntity>();
        }

        /// <summary>
        /// Генерирует и возвращает коллекцию сезонов в заданном количестве
        /// начиная с заданного номера сезона
        /// </summary>
        /// <param name="count">Количество сезонов</param>
        /// <param name="startSeasonNumber">Начальный номер сезона</param>
        /// <returns>Коллекция сезонов</returns>
        public List<SeasonEntity> Generate(
            int count,
            DateTime startDate,
            FakeEpisodeEntities episodeEntities,
            int startSeasonNumber = 1)
        {
            SeasonFaker
                .RuleFor(m => m.Number, startSeasonNumber++)
                .RuleFor(m => m.ListEpisode, f =>
                    {
                        episodeEntities.EpisodeFaker
                            .RuleFor(m => m.SeasonId, startSeasonNumber);
                        return episodeEntities.Generate(f.Random.Number(8, 22), startDate = startDate.AddYears(1));
                    }
                );

            var seasons = SeasonFaker.Generate(count);
            foreach (var seasonEntity in seasons)
            {
                foreach (var episodeEntity in seasonEntity.ListEpisode)
                {
                    episodeEntity.Season = seasonEntity;
                    episodeEntity.SeasonId = seasonEntity.Id;
                }
            }

            SeasonEntities.AddRange(seasons);
            return seasons;
        }
    }
}