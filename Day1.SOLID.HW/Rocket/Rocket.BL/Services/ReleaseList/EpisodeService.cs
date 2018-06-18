using AutoMapper;
using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Models.Pagination;
using Rocket.BL.Common.Services.ReleaseList;
using Rocket.DAL.Common.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.BL.Services.ReleaseList
{
    public class EpisodeService : BaseService, IEpisodeService
    {
        public EpisodeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public EpisodeFullDto GetEpisodesById(int id)
        {
            var episode = _unitOfWork.EpisodeRepository
                .Get(f => f.Id == id, includeProperties: $"{nameof(EpisodeEntity.Season)}")?.FirstOrDefault();

            if (episode == null)
            {
                return null;
            }

            episode.Season.TvSeries = _unitOfWork.TvSeriasRepository.GetById(episode.Season.TvSeriesId);
            return Mapper.Map<EpisodeFullDto>(episode);
        }

        public PageInfo<EpisodeFullDto> GetNewEpisodesPage(int pageSize, int pageNumber, int? genreId = null, string userId = null)
        {
            Expression<Func<EpisodeEntity, bool>> filter = f => f.ReleaseDateRu <= DateTime.Now;
            if (genreId != null)
            {
                if (userId != null)
                {
                    filter = f =>
                        f.Season.TvSeries.Users.Select(u => u.Id).Contains(userId) &&
                        f.Season.TvSeries.ListGenreEntity.Select(g => g.Id).Contains(genreId.Value) &&
                        f.ReleaseDateRu <= DateTime.Now;
                }
                else
                {
                    filter = f => f.Season.TvSeries.ListGenreEntity.Select(g => g.Id).Contains(genreId.Value) && f.ReleaseDateRu <= DateTime.Now;
                }
            }
            else if (userId != null)
            {
                filter = f =>
                    f.Season.TvSeries.Users.Select(u => u.Id).Contains(userId) &&
                    f.ReleaseDateRu <= DateTime.Now;
            }

            var pageInfo = new PageInfo<EpisodeFullDto>();
            pageInfo.TotalItemsCount = _unitOfWork.EpisodeRepository.ItemsCount(filter);
            pageInfo.TotalPagesCount = (int)Math.Ceiling((double)pageInfo.TotalItemsCount / pageSize);
            var episodes = _unitOfWork.EpisodeRepository.GetPage(
                    pageSize,
                    pageNumber,
                    filter,
                    o => o.OrderByDescending(e => e.ReleaseDateRu),
                    $"{nameof(EpisodeEntity.Season)}");

            foreach (var entity in episodes)
            {
                entity.Season.TvSeries = _unitOfWork.TvSeriasRepository.GetById(entity.Season.TvSeriesId);
            }

            pageInfo.PageItems = Mapper.Map<IEnumerable<EpisodeFullDto>>(episodes);
            return pageInfo;
        }

        public PageInfo<EpisodeDto> GetScheduleEpisodesPage(int pageSize, int pageNumber)
        {
            var pageInfo = new PageInfo<EpisodeDto>();
            pageInfo.TotalItemsCount = _unitOfWork.EpisodeRepository.ItemsCount(e => e.ReleaseDateRu > DateTime.Now);
            pageInfo.TotalPagesCount = (int)Math.Ceiling((double)pageInfo.TotalItemsCount / pageSize);
            var episodes = _unitOfWork.EpisodeRepository.GetPage(
                pageSize,
                pageNumber,
                f => f.ReleaseDateRu > DateTime.Now,
                o => o.OrderBy(e => e.ReleaseDateRu),
                $"{nameof(EpisodeEntity.Season)}");

            foreach (var entity in episodes)
            {
                entity.Season.TvSeries = _unitOfWork.TvSeriasRepository.GetById(entity.Season.TvSeriesId);
            }

            pageInfo.PageItems = Mapper.Map<IEnumerable<EpisodeDto>>(episodes);
            return pageInfo;
        }

        public IEnumerable<EpisodeDto> GetEpisodesByDates(DateTime startDate, DateTime endDate, string userId = null)
        {
            Expression<Func<EpisodeEntity, bool>> filter = f =>
                f.ReleaseDateRu >= startDate && f.ReleaseDateRu <= endDate;
            if (userId != null)
            {
                filter = f =>
                    f.Season.TvSeries.Users.Select(u => u.Id).Contains(userId) &&
                    f.ReleaseDateRu >= startDate && f.ReleaseDateRu <= endDate;
            }

            var episodes = _unitOfWork.EpisodeRepository.Get(
                filter,
                includeProperties: $"{nameof(EpisodeEntity.Season)}");

            foreach (var entity in episodes)
            {
                entity.Season.TvSeries = _unitOfWork.TvSeriasRepository.GetById(entity.Season.TvSeriesId);
            }

            return Mapper.Map<IEnumerable<EpisodeDto>>(episodes);
        }
    }
}
