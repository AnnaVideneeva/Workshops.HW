using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Common.Repositories.Notification
{
    /// <summary>
    /// Представляет интерфейс репозитория для сообщений с информацией о совершенном гостем донате
    /// </summary>
    public interface IDbGuestBillingMessageRepository : IBaseRepository<DbGuestBillingMessage>
    {
    }
}