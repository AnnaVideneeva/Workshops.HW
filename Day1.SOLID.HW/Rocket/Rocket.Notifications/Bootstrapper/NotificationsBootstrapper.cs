using System.Collections.Generic;
using Ninject.Modules;
using Rocket.BL;
using Rocket.DAL;
using Rocket.Notifications.Config;
using Rocket.Notifications.Interfaces;
using Rocket.Web;

namespace Rocket.Notifications.Bootstrapper
{
    class NotificationsBootstrapper : INinjectModuleBootstrapper
    {
        public IList<INinjectModule> GetModules()
        {
            return new List<INinjectModule>()
            {
                new WebModule(),
                new DALModule(),
                new BLModule(),
                new NotificationsModule()
            };
        }
    }
}
