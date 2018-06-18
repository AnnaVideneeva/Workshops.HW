using System.Collections.Generic;
using Rocket.BL.Common.Models.Subscription;
using Rocket.Web.Models;

namespace Rocket.Web.Helpers
{
    public interface IPushNotificationsHelper
    {
        /// <summary>
        /// Отослать сообщения о выходе релизов
        /// </summary>
        /// <param name="notifications">Коллекция push-уведомлений</param>
        void SendPushNotificationsOfRelease(IEnumerable<PushNotificationModel> notifications);
    }
}