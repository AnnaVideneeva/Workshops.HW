using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Rocket.BL.Common.Models.User;
using Rocket.BL.Common.Models.UserRoles;
using Rocket.BL.Services.UserServices;
using Swashbuckle.Swagger.Annotations;

namespace Rocket.Web.Controllers.UserRole
{
    [RoutePrefix("permission")]
    public class PermissionController : ApiController
    {
        private readonly PermissionService _permissionService;

        public PermissionController(PermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        
        [HttpGet]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult GetPermissionById(string id)
        {
            var model = _permissionService.GetPermissionByYser(id);

            return model == null ? (IHttpActionResult)NotFound() : Ok(model);
        }

        [HttpGet]
        [Route("GetPermissionByRole{id:int:min(1)}")]
        public IHttpActionResult GetPermissionByRole(string user)
        {
            var model = _permissionService.GetPermissionByYser(user);
            return model == null ? (IHttpActionResult)NotFound() : Ok(model);
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllPermissions()
        {
            //_permissionService.Get(null, null, "Permission");
            var model = _permissionService.GetAllPermissions();
            return model == null ? (IHttpActionResult)NotFound() : Ok(model);
        }

        [HttpPost]
        [SwaggerResponseRemoveDefaults]
        //[SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid", typeof(string))]
        //[SwaggerResponse(HttpStatusCode.Created, "New Permission description", typeof(Permission))]
        public IHttpActionResult InsertPermission(Permission permission, string user)
        {
            if (permission == null)
            {
                return BadRequest("Model cannot be empty");
            }

            _permissionService.Insert(permission, user);
            return Created($"permission/{permission.PermissionId}", permission);
        }

        /*
        [HttpPut]
        public IHttpActionResult UpdatePermission([FromBody]Permission permission, string user)
        {
            if (permission == null)
            {
                return BadRequest("Model cannot be empty");
            }

            _permissionService.Update(permission, user);

            return new StatusCodeResult(HttpStatusCode.NoContent, Request);
        }
        */

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult DeletePermissionById(Permission permission, string user)
        {
            /*
            if (_permissionService.GetById(permission.PermissionId.ToString()) == null)
            {
                return BadRequest("The permission not exists");
            }
            */

            _permissionService.Delete(permission, user);
            return new StatusCodeResult(HttpStatusCode.Accepted, Request);
        }
    }
}