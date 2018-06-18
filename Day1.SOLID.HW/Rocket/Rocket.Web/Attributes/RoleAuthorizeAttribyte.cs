using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Rocket.Web.Attributes
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public string ClaimName { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var identity = actionContext.RequestContext.Principal.Identity as ClaimsIdentity;
            identity?.HasClaim(c => c.Type.Equals("permission") && c.Value.Equals("read"));

            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}