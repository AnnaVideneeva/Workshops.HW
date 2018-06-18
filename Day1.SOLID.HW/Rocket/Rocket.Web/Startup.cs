using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.AccessTokenValidation;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Context;
using Rocket.Web.Identity;
using Rocket.Web.Owin;

[assembly: OwinStartup(typeof(Rocket.Web.Startup))]

namespace Rocket.Web
{
    public class Startup
    {
        // todo MP1. AppHandler
        // todo MP2. AuthorizeAttribute
        // todo MP6. canActivate: [RocketAuthGuard] front

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.MapSignalR();

            var factory =
                new IdentityServerServiceFactory()
                {
                    UserService =
                            new Registration<IUserService, RocketIdentityService>()
                }
                    .UseInMemoryClients(Clients.Load())
                    .UseInMemoryScopes(Scopes.Load());


            factory.Register(new Registration<UserManager<DbUser, string>>());
            factory.Register(new Registration<IUserStore<DbUser, string>>(resolver => new UserStore<DbUser>(new RocketContext())));

            app.UseIdentityServer(new IdentityServerOptions
            {
                RequireSsl = false,
                SiteName = "Identity Server",
                SigningCertificate = LoadCertificate(),
                EnableWelcomePage = false,
                Factory = factory
            });

            var opt = new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://rocket-api.belpyro.net",
                RequiredScopes = new[] { "openid" },
                IssuerName = "http://rocket-api.belpyro.net",
                SigningCertificate = LoadCertificate(),
                ValidationMode = ValidationMode.Local
            };

            app.UseIdentityServerBearerTokenAuthentication(opt);
        }

        private X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\idsrv3test.pfx"), "idsrv3test");
        }
    }
}