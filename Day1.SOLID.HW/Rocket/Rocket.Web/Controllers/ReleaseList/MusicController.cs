using System;
using System.Web.Http;
using Rocket.BL.Common.Services.ReleaseList;
using Rocket.Web.ConfigHandlers;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;

namespace Rocket.Web.Controllers.ReleaseList
{
    [RoutePrefix("music")]
    public class MusicController : ApiController
    {
        private readonly IMusicDetailedInfoService _musicDetailedInfoService;

        public MusicController(IMusicDetailedInfoService musicDetailedInfoService)
        {
            _musicDetailedInfoService = musicDetailedInfoService;
        }

        /// <summary>
        /// Возвращает информацию о музыкальном релизе
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Музыкальный релиз</returns>
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult GetMusicById(int id)
        {
            var model = _musicDetailedInfoService.GetMusic(id);
            return model == null ? (IHttpActionResult)NotFound() : Ok(model);
        }

        /// <summary>
        /// Возвращает страницу музыкальном релизов с заданным номером страницы
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="genreId">Идентификатор жанра</param>
        /// <returns>Страница музыкальных релизов</returns>
        [HttpGet]
        [Route("page/{pageNumber:int:min(1)}")]
        public IHttpActionResult GetMusicByPage(int pageNumber, int? genreId = null)
        {
            var page = _musicDetailedInfoService.GetPageInfoByDate(
                SettingsManager.ReleasesSettings.Pagination.PageSize,
                pageNumber,
                    genreId,
                User.GetUserId());
            return pageNumber <= page.TotalPagesCount ? Ok(page) : (IHttpActionResult)NotFound();
        }

        /// <summary>
        /// Возвращает страницу музыкальном релизов с заданным номером страницы
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="genreId">Идентификатор жанра</param>
        /// <returns>Страница музыкальных релизов</returns>
        [HttpGet]
        [Route("new/page/{pageNumber:int:min(1)}")]
        public IHttpActionResult GetNewMusicByPage(int pageNumber, int? genreId = null)
        {
            var page = _musicDetailedInfoService.GetNewPageInfoByDate(
                SettingsManager.ReleasesSettings.Pagination.PageSize,
                pageNumber,
                genreId,
                User.GetUserId());
            return pageNumber <= page.TotalPagesCount ? Ok(page) : (IHttpActionResult)NotFound();
        }

        /// <summary>
        /// Возвращает коллекцию музыкальных релизов с датой выхода
        /// между заданными начальной и конечной датами включительно
        /// </summary>
        /// <param name="start_date">Начальная дата</param>
        /// <param name="end_date">Конечная дата</param>
        /// <returns>Коллекция музыкальных релизов</returns>
        [HttpGet]
        [Route("calendar")]
        public IHttpActionResult GetMusicByDates(DateTime start_date, DateTime end_date)
        {
            if (start_date > end_date)
            {
                return BadRequest(Resources.BadStartEndDatesMessage);
            }

            var musics = _musicDetailedInfoService.GetMusicByDates(start_date.Date, end_date.Date, User.GetUserId());
            return Ok(musics);
        }
    }
}
