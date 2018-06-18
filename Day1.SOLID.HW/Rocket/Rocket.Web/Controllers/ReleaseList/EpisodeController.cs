using System;
using Rocket.BL.Common.Services.ReleaseList;
using Rocket.Web.ConfigHandlers;
using System.Web.Http;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;

namespace Rocket.Web.Controllers.ReleaseList
{
    [RoutePrefix("episode")]
    public class EpisodeController : ApiController
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        /// <summary>
        /// Возвращает серию с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор серии</param>
        /// <returns>Серия</returns>
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult GetEpisodeById(int id)
        {
            var episode = _episodeService.GetEpisodesById(id);
            return episode != null ? Ok(episode) : (IHttpActionResult)NotFound();
        }

        /// <summary>
        /// Возвращает страницу новых серий
        /// с заданным номером и размером страницы
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="page_size">Размер страницы</param>
        /// <param name="genre_id">Идентификатор жанра</param>
        /// <returns>Страница новых серий</returns>
        [HttpGet]
        [Route("new/page_{pageNumber:int:min(1)}")]
        public IHttpActionResult GetNewEpisodesByPage(int pageNumber, int? page_size = null, int? genre_id = null)
        {
            if (page_size.HasValue && page_size.Value < 1)
            {
                return BadRequest(Resources.BadPageSizeMessage);
            }

            var page = _episodeService.GetNewEpisodesPage(page_size ?? SettingsManager.ReleasesSettings.Pagination.PageSize, pageNumber, genre_id, User.GetUserId());
            return pageNumber <= page.TotalPagesCount ? Ok(page) : (IHttpActionResult)NotFound();
        }

        /// <summary>
        /// Возвращает страницу будущих серий
        /// с заданным номером и размером страницы
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="page_size">Размер страницы</param>
        /// <returns>Страница будущих серий</returns>
        [HttpGet]
        [Route("schedule/page_{pageNumber:int:min(1)}")]
        public IHttpActionResult GetScheduleEpisodesByPage(int pageNumber, int? page_size = null)
        {
            if (page_size.HasValue && page_size.Value < 1)
            {
                return BadRequest(Resources.BadPageSizeMessage);
            }

            var page = _episodeService.GetScheduleEpisodesPage(page_size ?? SettingsManager.ReleasesSettings.Pagination.PageSize, pageNumber);
            return pageNumber <= page.TotalPagesCount ? Ok(page) : (IHttpActionResult)NotFound();
        }

        /// <summary>
        /// Возвращает коллекцию серий с датой выхода
        /// между заданными начальной и конечной датами включительно
        /// </summary>
        /// <param name="start_date">Начальная дата</param>
        /// <param name="end_date">Конечная дата</param>
        /// <returns>Коллекция серий</returns>
        [HttpGet]
        [Route("calendar")]
        public IHttpActionResult GetEpisodesByDates(DateTime start_date, DateTime end_date)
        {
            if (start_date > end_date)
            {
                return BadRequest(Resources.BadStartEndDatesMessage);
            }

            var episodes = _episodeService.GetEpisodesByDates(start_date.Date, end_date.Date, User.GetUserId());
            return Ok(episodes);
        }
    }
}
