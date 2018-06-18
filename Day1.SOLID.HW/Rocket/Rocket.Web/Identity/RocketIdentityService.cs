using System;
using IdentityServer3.AspNetIdentity;
using Microsoft.AspNet.Identity;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.Web.Identity
{
    public class RocketIdentityService : AspNetIdentityUserService<DbUser, string>
    {
        public RocketIdentityService(UserManager<DbUser, string> userManager, Func<string, string> parseSubject = null) 
            : base(userManager, parseSubject)
        {
        }
    }
}