using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace Rocket.Web.Owin
{
    public static class Clients
    {
        public static IEnumerable<Client> Load()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "client",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret-rocket".Sha256())
                    },
                    ClientName = "Android",
                    AllowAccessToAllScopes = true,
                    Flow = Flows.ResourceOwner,
                }
            };
        }
    }
}