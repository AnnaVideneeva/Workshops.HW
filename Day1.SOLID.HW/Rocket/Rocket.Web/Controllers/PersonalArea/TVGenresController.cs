using FluentValidation;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;

namespace Rocket.Web.Controllers.PersonalArea
{
    public class TVGenresController : ApiController
    {
        private readonly ITVGenreManager _genreManager;

        public TVGenresController(ITVGenreManager genreManager)
        {
            _genreManager = genreManager;
        }

        [HttpGet]
        [Route("genres/all/tv")]
        public IHttpActionResult GetAllTvGenres()
        {
            var tvGenres = _genreManager.GetAllTvGenres();
            return tvGenres == null ? (IHttpActionResult)NotFound() : Ok(tvGenres);
        }

        [HttpPut]
        [Route("personal/genres/tv/add")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Genre is not valid", typeof(string))]
        public IHttpActionResult SaveTvGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest(Resources.EmptyGenre);
            }

            try
            {
                _genreManager.AddTvGenre(User.GetUserId(), genre);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("personal/genres/tv/delete")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Genre is not valid", typeof(string))]
        public IHttpActionResult DeleteTvGenre(string id, string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest(Resources.EmptyGenre);
            }

            try
            {
                _genreManager.DeleteTvGenre(User.GetUserId(), genre);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}