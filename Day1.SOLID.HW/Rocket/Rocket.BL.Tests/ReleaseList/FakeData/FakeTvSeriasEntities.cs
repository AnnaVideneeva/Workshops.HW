using Bogus;
using Rocket.DAL.Common.DbModels.Parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Rocket.BL.Tests.ReleaseList.FakeData
{
    /// <summary>
    /// Представляет набор сгенерированных данных о сериалах,
    /// в моделях хранения данных
    /// </summary>
    public class FakeTvSeriasEntities
    {
        /// <summary>
        /// Возвращает генератор данных о сериалах
        /// </summary>
        public Faker<TvSeriasEntity> TvSeriasFaker { get; }

        /// <summary>
        /// Возвращает коллекцию сгенерированных сериалов
        /// </summary>
        public List<TvSeriasEntity> TvSeriasEntities { get; }

        /// <summary>
        /// Создает новый экземпляр сгенерированных данных о сериалах
        /// </summary>
        /// <param name="personsCount">Необходимое количество сгенерированных людей</param>
        /// <param name="genresCount">Необходимое количество сгенерированных жанров видео</param>
        /// <param name="tvSerialsCount">Необходимое количество сгенерированных сериалах</param>
        public FakeTvSeriasEntities(
            int tvSeriasCount,
            FakePersonEntities personEntities,
            FakeGenreEntities genreEntities,
            FakeSeasonEntities seasonEntities,
            FakeEpisodeEntities episodeEntities)
        {
            var loremRu = new Bogus.DataSets.Lorem("ru");
            TvSeriasFaker = new Faker<TvSeriasEntity>()
                .RuleFor(m => m.Id, f => f.IndexFaker)
                .RuleFor(m => m.TitleEn, f => string.Join(" ", f.Lorem.Words(2)))
                .RuleFor(m => m.TitleEn, f => string.Join(" ", loremRu.Words(2)))
                .RuleFor(m => m.PosterImageUrl, f => f.Internet.Url())
                .RuleFor(m => m.LostfilmRate, f => f.Random.Double(1, 10))
                .RuleFor(m => m.RateImDb, f => f.Random.Double(1, 10))
                .RuleFor(m => m.UrlToOfficialSite, f => f.Internet.Url())
                .RuleFor(m => m.Summary, f => f.Lorem.Text())
                .RuleFor(m => m.ListPerson, f => f.PickRandom(personEntities.PersonEntities, 30).ToList())
                .RuleFor(m => m.ListGenreEntity, f => f.PickRandom(genreEntities.GenreEntities, 3).ToList())
                .RuleFor(m => m.ListSeasons, f => seasonEntities.Generate(
                    f.Random.Number(1, 13),
                    f.Date.Between(new DateTime(1995, 1, 1), new DateTime(2020, 12, 31)),
                    episodeEntities));

            TvSeriasEntities = TvSeriasFaker.Generate(tvSeriasCount);

            foreach (var tvSeriasEntity in TvSeriasEntities)
            {
                foreach (var seasonEntity in tvSeriasEntity.ListSeasons)
                {
                    seasonEntity.TvSeriesId = tvSeriasEntity.Id;
                    seasonEntity.TvSeries = tvSeriasEntity;
                }

                foreach (var genreEntity in tvSeriasEntity.ListGenreEntity)
                {
                    genreEntity.ListTvSerias.Add(tvSeriasEntity);
                }

                foreach (var personEntity in tvSeriasEntity.ListPerson)
                {
                    personEntity.ListTvSerias.Add(tvSeriasEntity);
                }
            }
        }
    }
}