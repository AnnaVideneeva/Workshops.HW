using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rocket.BL.Common.Services.ReleaseList;

namespace Rocket.Web.Controllers.ReleaseList
{
    [RoutePrefix("genre")]
    public class GenreController : ApiController
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Route("series/all")]
        public IHttpActionResult GetAllTvSeriesGenres()
        {
            var genres = _genreService.GetTvSeriesGenres();
            return genres == null ? (IHttpActionResult)NotFound() : Ok(genres);
        }

        [HttpGet]
        [Route("music/all")]
        public IHttpActionResult GetAllMusicGenres()
        {
            var genres = _genreService.GetMusicGenres();
            return genres == null ? (IHttpActionResult)NotFound() : Ok(genres);
        }
    }
}
