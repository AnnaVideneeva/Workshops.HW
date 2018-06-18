using FluentValidation;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace Rocket.Web.Controllers.PersonalArea
{
    [RoutePrefix("personal/email")]
    public class EmailController : ApiController
    {
        private IEmailManager _emailEmailManager;

        public EmailController(IEmailManager emailManager)
        {
            _emailEmailManager = emailManager;
        }

        [HttpPost]
        [Route("add")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Model is not valid", typeof(string))]
        [SwaggerResponse(HttpStatusCode.Created, "New model description", typeof(Email))]
        public IHttpActionResult AddEmail(Email email)
        {
            int mail;
            if (email == null)
            {
                return BadRequest(Resources.EmptyEmail);
            } 
            
            try
            {
                mail = _emailEmailManager.AddEmail(User.GetUserId(), email);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            email.Id = mail;
            return Created($"{mail}", email);
        }

        [HttpDelete]
        [Route("delete/{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Id is not valid", typeof(string))]
        public IHttpActionResult DeleteEmail(int id)
        {
            try
            {
                _emailEmailManager.DeleteEmail(id);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return new StatusCodeResult(HttpStatusCode.NoContent, Request);
        }
    }
}