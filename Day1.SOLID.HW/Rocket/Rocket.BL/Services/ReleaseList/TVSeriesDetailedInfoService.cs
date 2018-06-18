using AutoMapper;
using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Models.Pagination;
using Rocket.BL.Common.Services.ReleaseList;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Castle.Core.Internal;

namespace Rocket.BL.Services.ReleaseList
{
    /// <summary>
    /// Представляет сервис для работы с детальной информацией
    /// о сериалах в хранилище данных
    /// </summary>
    public class TvSeriesDetailedInfoService : BaseService, ITvSeriesDetailedInfoService
    {
        /// <summary>
        /// Создает новый экземпляр <see cref="TvSeriesDetailedInfoService"/>
        /// с заданным unit of work
        /// </summary>
        /// <param name="unitOfWork">Экземпляр unit of work</param>
        public TvSeriesDetailedInfoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public PageInfo<TvSeriesMinimalDto> GetPageInfo(int pageSize, int pageNumber, int? genreId = null, string userId = null)
        {
            Expression<Func<TvSeriasEntity, bool>> filter = null;
            if (genreId != null)
            {
                filter = f => f.ListGenreEntity.Select(g => g.Id).Contains(genreId.Value);
            }

            var pageInfo = new PageInfo<TvSeriesMinimalDto>();
            pageInfo.TotalItemsCount = _unitOfWork.TvSeriasRepository.ItemsCount(filter);
            pageInfo.TotalPagesCount = (int)Math.Ceiling((double)pageInfo.TotalItemsCount / pageSize);
            pageInfo.PageItems = Mapper.Map<IEnumerable<TvSeriasEntity>, IEnumerable<TvSeriesMinimalDto>>(
                _unitOfWork.TvSeriasRepository.GetPage(
                    pageSize,
                    pageNumber,
                    filter,
                    o => o.OrderByDescending(t => t.LostfilmRate),
                    $"{nameof(TvSeriasEntity.ListGenreEntity)},{nameof(TvSeriasEntity.Users)}"),
                opts => opts.AfterMap((src, dest) =>
                {
                    foreach (var tvSeries in dest)
                    {
                        tvSeries.IsUserSubscribed = src.First(x => x.Id == tvSeries.Id).Users.Any(x => x.Id == userId);
                    }
                }));

            return pageInfo;
        }

        public TvSeriesFullDto GetTvSeries(int id, int? episodesCount = null, int? personsCount = null)
        {
            var tvSeries = _unitOfWork.TvSeriasRepository
                .Get(
                    f => f.Id == id,
                    includeProperties: $"{nameof(TvSeriasEntity.ListGenreEntity)},{(episodesCount == 0 ? string.Empty : nameof(TvSeriasEntity.ListSeasons))}")
                ?.FirstOrDefault();

            if (tvSeries == null)
            {
                return null;
            }

            if (personsCount == null || personsCount > 0)
            {
                var count = personsCount ??
                            _unitOfWork.PersonRepository.ItemsCount(f => f.ListTvSerias.Select(t => t.Id).Contains(id));
                tvSeries.ListPerson = _unitOfWork.PersonRepository.GetPage(
                    count,
                    1,
                    f => f.ListTvSerias.Select(t => t.Id).Contains(id),
                    o => o.OrderBy(p => p.Id),
                    $"{nameof(PersonEntity.PersonType)}").ToList();
            }

            if (tvSeries.ListSeasons != null)
            {
                var count = episodesCount ?? _unitOfWork.EpisodeRepository.ItemsCount(f => f.Season.TvSeriesId == id);
                var lastEpisodes = _unitOfWork.EpisodeRepository.GetPage(
                    count,
                    1,
                    f => f.Season.TvSeriesId == id,
                    o => o.OrderBy(e => e.Id));
                foreach (var season in tvSeries.ListSeasons)
                {
                    season.ListEpisode = lastEpisodes.Where(e => e.SeasonId == season.Id).ToList();
                }
            }

            return Mapper.Map<TvSeriesFullDto>(tvSeries);
        }

        public TvSeriesSeasonsDto GetSeasons(int id)
        {
            var tvSeries = _unitOfWork.TvSeriasRepository
                .GetById(id);

            if (tvSeries == null)
            {
                return null;
            }

            tvSeries.ListSeasons = _unitOfWork.SeasonRepository
                .Get(f => f.TvSeriesId == id, includeProperties: $"{nameof(SeasonEntity.ListEpisode)}").ToList();

            return Mapper.Map<TvSeriesSeasonsDto>(tvSeries);
        }

        public TvSeriesPersonsDto GetPersons(int id)
        {
            var tvSeries = _unitOfWork.TvSeriasRepository
                .GetById(id);

            if (tvSeries == null)
            {
                return null;
            }

            tvSeries.ListPerson = _unitOfWork.PersonRepository
                .Get(
                    f => f.ListTvSerias.Select(t => t.Id).Contains(id),
                    includeProperties: $"{nameof(PersonEntity.PersonType)}").ToList();

            return Mapper.Map<TvSeriesPersonsDto>(tvSeries);
        }
    }
}