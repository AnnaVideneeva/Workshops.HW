using System;
using System.Security.Claims;
using System.Security.Principal;

namespace Rocket.Web.Extensions
{
    public static class PrincipalExtensions
    {
        public static string GetUserId(this IPrincipal user)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }
    }
}