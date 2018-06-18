using System.Collections.Generic;
using Rocket.Web.Hubs;
using Rocket.Web.Models;

namespace Rocket.Web.Helpers
{
    /// <summary>
    /// Выполняет рассылку push-уведомлений
    /// </summary>
    public class PushNotificationsHelper : IPushNotificationsHelper
    {
        /// <inheritdoc />
        /// <summary>
        /// Отослать сообщения о выходе релизов
        /// </summary>
        /// <param name="notifications">Коллекция push-уведомлений</param>
        public void SendPushNotificationsOfRelease(IEnumerable<PushNotificationModel> notifications)
        {
            foreach (var notification in notifications)
            {
                NotificationHub.NotifyOfRelease(notification.Message, notification.Users);
            }
        }
    }
}