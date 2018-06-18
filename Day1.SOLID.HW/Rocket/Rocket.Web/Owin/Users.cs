using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core.Services.InMemory;

namespace Rocket.Web.Owin
{
    public static class Users
    {
        public static List<InMemoryUser> Load()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser()
                {
                    Subject = "user123",
                    Username = "user",
                    Password = "password",
                    Claims = new List<Claim>()
                    {
                        new Claim("shirt_size", "XXL")
                    }
                }
            };
        }
    }
}