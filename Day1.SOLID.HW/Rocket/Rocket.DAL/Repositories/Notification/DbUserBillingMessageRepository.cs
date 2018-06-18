using Rocket.DAL.Common.DbModels.Notification;
using Rocket.DAL.Common.Repositories.Notification;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.Notification
{
    /// <summary>
    /// Представляет репозиторий для сообщений с информацией о совершенных
    /// пользователем платежах на сайте (покупка премиум аккаунта, донат)
    /// </summary>
    public class DbUserBillingMessageRepository : BaseRepository<DbUserBillingMessage>, IDbUserBillingMessageRepository
    {
        /// <summary>
        /// Создает новый экземпляр репозитория для сообщений с информацией о совершенных
        /// пользователем платежах на сайте (покупка премиум аккаунта, донат)
        /// с заданным контекстом базы данных
        /// </summary>
        /// <param name="dbContext">Экземпляр контекста базы данных</param>
        public DbUserBillingMessageRepository(RocketContext dbContext)
            : base(dbContext)
        {
        }
    }
}
