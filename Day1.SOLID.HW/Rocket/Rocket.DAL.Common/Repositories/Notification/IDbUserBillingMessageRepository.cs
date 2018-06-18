using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Common.Repositories.Notification
{
    /// <summary>
    /// Представляет интерфейс репозитория для сообщений с информацией о совершенных
    /// пользователем платежах на сайте (покупка премиум аккаунта, донат)
    /// </summary>
    public interface IDbUserBillingMessageRepository : IBaseRepository<DbUserBillingMessage>
    {
    }
}