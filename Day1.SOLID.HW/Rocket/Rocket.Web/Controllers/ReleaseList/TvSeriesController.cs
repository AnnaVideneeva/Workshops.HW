using Rocket.BL.Common.Services.ReleaseList;
using System.Web.Http;
using IdentityServer3.Core.Extensions;
using Rocket.Web.ConfigHandlers;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;

namespace Rocket.Web.Controllers.ReleaseList
{
    [RoutePrefix("tvseries")]
    public class TvSeriesController : ApiController
    {
        private readonly ITvSeriesDetailedInfoService _tvSeriesDetailedInfoService;

        public TvSeriesController(ITvSeriesDetailedInfoService tvSeriesDetailedInfoService)
        {
            _tvSeriesDetailedInfoService = tvSeriesDetailedInfoService;
        }

        /// <summary>
        /// Возвращает информацию о сериале с заданным идентификатором,
        /// количеством возвращаемых последних серий и количеством участников
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="episodes_count">Количество последних серий</param>
        /// <param name="persons_count">Количество участников сериала</param>
        /// <returns>Сериал</returns>
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult GetTvSeriesById(int id, int? episodes_count = null, int? persons_count = null)
        {
            if (episodes_count.HasValue && episodes_count < 0)
            {
                return BadRequest(Resources.BadPersonCountMessage);
            }

            if (persons_count.HasValue && persons_count < 0)
            {
                return BadRequest(Resources.BadEpisodesCountMessage);
            }

            var tvSeries = _tvSeriesDetailedInfoService.GetTvSeries(id, episodes_count, persons_count);
            return tvSeries == null ? (IHttpActionResult)NotFound() : Ok(tvSeries);
        }

        /// <summary>
        /// Возвращает страницу сериалов с заданным номером, размером страницы
        /// и идентификатором жанра
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="page_size">Размер страницы</param>
        /// <param name="genre_id">Идентификатор жанра</param>
        /// <returns>Страница сериалов</returns>
        [HttpGet]
        [Route("page_{pageNumber:int:min(1)}")]
        public IHttpActionResult GetTvSerialsByPage(int pageNumber, int? page_size = null, int? genre_id = null)
        {
            if (page_size.HasValue && page_size.Value < 1)
            {
                return BadRequest(Resources.BadPageSizeMessage);
            }

            var page = _tvSeriesDetailedInfoService.GetPageInfo(
                page_size ?? SettingsManager.ReleasesSettings.Pagination.PageSize,
                pageNumber,
                genre_id,
                User.GetUserId());
            return pageNumber <= page.TotalPagesCount ? Ok(page) : (IHttpActionResult)NotFound();
        }

        /// <summary>
        /// Возвращает сезоны сериала
        /// </summary>
        /// <param name="id">Идентификатор сериала</param>
        /// <returns>Сезоны сериала</returns>
        [HttpGet]
        [Route("{id:int:min(1)}/seasons")]
        public IHttpActionResult GetTvSeriesSeasons(int id)
        {
            var tvSeries = _tvSeriesDetailedInfoService.GetSeasons(id);
            return tvSeries == null ? (IHttpActionResult)NotFound() : Ok(tvSeries);
        }

        /// <summary>
        /// Возвращает участников сериала
        /// </summary>
        /// <param name="id">Идентификатор сериала</param>
        /// <returns>Участники сериала</returns>
        [HttpGet]
        [Route("{id:int:min(1)}/cast")]
        public IHttpActionResult GetTvSeriesCast(int id)
        {
            var tvSeries = _tvSeriesDetailedInfoService.GetPersons(id);
            return tvSeries == null ? (IHttpActionResult)NotFound() : Ok(tvSeries);
        }
    }
}