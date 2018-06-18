using AutoMapper;
using Rocket.BL.Common.Models.Pagination;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.BL.Common.Services.ReleaseList;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rocket.BL.Services.ReleaseList
{
    /// <summary>
    /// Представляет сервис для получения ленты новостей для гостя
    /// </summary>
    public class GuestReleaseListService : BaseService, IGuestReleaseListService
    {
        /// <summary>
        /// Создает новый экземпляр <see cref="GuestReleaseListService"/>
        /// с заданным unit of work
        /// </summary>
        /// <param name="unitOfWork">Экземпляр unit of work</param>
        public GuestReleaseListService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        /// <summary>
        /// Возвращает страницу вышедших релизов с заданным номером и размером
        /// </summary>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns>Информация о странице релизов</returns>
        public ReleasesPageInfo GetPublishedReleasesPage(int pageSize, int pageNumber)
        {
            return GetFilteredPage(
                pageSize,
                pageNumber,
                r => r.ReleaseDate <= DateTime.Now,
                o => o.OrderByDescending(k => k.ReleaseDate));
        }

        /// <summary>
        /// Возвращает страницу будущих релизов с заданным номером и размером
        /// </summary>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns>Информация о странице релизов</returns>
        public ReleasesPageInfo GetFutureReleasesPage(int pageSize, int pageNumber)
        {
            return GetFilteredPage(
                pageSize,
                pageNumber,
                r => r.ReleaseDate > DateTime.Now,
                o => o.OrderBy(k => k.ReleaseDate));
        }

        private ReleasesPageInfo GetFilteredPage(
            int pageSize,
            int pageNumber,
            Expression<Func<DbBaseRelease, bool>> filter,
            Func<IQueryable<DbBaseRelease>, IOrderedQueryable<DbBaseRelease>> orderBy)
        {
            var pageInfo = new ReleasesPageInfo();
            //pageInfo.TotalItemsCount = _unitOfWork.ReleaseRepository.ItemsCount(filter);
            //pageInfo.TotalPagesCount = (int)Math.Ceiling((double)pageInfo.TotalItemsCount / pageSize);
            //pageInfo.PageItems = Mapper.Map<IEnumerable<BaseRelease>>(
            //    _unitOfWork.ReleaseRepository.GetPage(pageSize, pageNumber, filter, orderBy));

            return pageInfo;
        }
    }
}