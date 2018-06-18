using System;
using Ninject;
using Ninject.Web.Common.WebHost;
using Rocket.Web.Attributes;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Rocket.Web.App_Handler;

namespace Rocket.Web
{
    public class Global : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.Initialize();
            //GlobalFilters.Filters.Add(new RoleAuthorizeAttribute());
            LoggerConfig.Configure();
        }

        //расскоментировать перед запуском
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Server.ClearError();

            var errorHandler = DependencyResolver.Current.GetService<ApplicationErrorHandler>();
            errorHandler.Handle(User, Request, Response, exception);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(new[] { "Rocket.BL*", "Rocket.DAL*" });

            kernel.Load<WebModule>();

            return kernel;
        }
    }
}