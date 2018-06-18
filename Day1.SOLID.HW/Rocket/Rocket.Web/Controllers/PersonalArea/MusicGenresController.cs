using FluentValidation;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;

namespace Rocket.Web.Controllers.PersonalArea
{
    public class MusicGenresController : ApiController
    {
        private readonly IMusicGenreManager _genreManager;

        public MusicGenresController(IMusicGenreManager genreManager)
        {
            _genreManager = genreManager;
        }

        [HttpGet]
        [Route("genres/all/music")]
        public IHttpActionResult GetAllMusicGenres()
        {
            var musicGenres = _genreManager.GetAllMusicGenres();
            return musicGenres == null ? (IHttpActionResult)NotFound() : Ok(musicGenres);
        }

        [HttpPut]
        [Route("personal/genres/music/add")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Genre is not valid", typeof(string))]
        public IHttpActionResult SaveMusicGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest(Resources.EmptyGenre);
            }

            try
            {
                _genreManager.AddMusicGenre(User.GetUserId(), genre);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("personal/genres/music/delete")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Genre is not valid", typeof(string))]
        public IHttpActionResult DeleteMusicGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest(Resources.EmptyGenre);
            }

            try
            {
                _genreManager.DeleteMusicGenre(User.GetUserId(), genre);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}