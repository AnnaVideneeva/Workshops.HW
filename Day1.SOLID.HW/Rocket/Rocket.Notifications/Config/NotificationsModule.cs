using Ninject.Modules;
using Rocket.DAL.Context;
using Rocket.Notifications.Interfaces;
using System.Net.Http;

namespace Rocket.Notifications.Config
{
    public class NotificationsModule : NinjectModule
    {
        /// <inheritdoc />
        /// <summary>
        /// Настройка Ninject для уведомлений
        /// </summary>
        public override void Load()
        {
            Rebind<RocketContext>().ToMethod(ctx => new RocketContext()).InSingletonScope();
            Bind<HttpClient>().ToMethod(ctx => new HttpClient()).InSingletonScope();
            Bind<IPushNotificator>().To<Notificator.Notificator>();
        }
    }
}
