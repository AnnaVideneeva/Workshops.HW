using System.Threading.Tasks;

namespace Rocket.Notifications.Interfaces
{
    /// <summary>
    /// Интерфейс инициации отправки уведомлений
    /// </summary>
    public interface IPushNotificator
    {
        /// <summary>
        /// Отправка уведомлений
        /// </summary>
        /// <returns></returns>
        Task NotifyAsync();
    }
}