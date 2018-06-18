using Rocket.DAL.Common.DbModels.Notification;
using Rocket.DAL.Common.Repositories.Notification;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.Notification
{
    /// <summary>
    /// Представляет репозиторий для пользователей, являющихся получателями сообщений
    /// </summary>
    public class DbReceiverRepository : BaseRepository<DbReceiver>, IDbReceiverRepository
    {
        /// <summary>
        /// Создает новый экземпляр репозитория для пользователей, являющихся получателями сообщений
        /// с заданным контекстом базы данных
        /// </summary>
        /// <param name="dbContext">Экземпляр контекста базы данных</param>
        public DbReceiverRepository(RocketContext dbContext)
            : base(dbContext)
        {
        }
    }
}