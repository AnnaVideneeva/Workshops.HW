using Rocket.DAL.Common.DbModels.Notification;
using Rocket.DAL.Common.Repositories.Notification;
using Rocket.DAL.Context;

namespace Rocket.DAL.Repositories.Notification
{
    /// <summary>
    /// Представляет репозиторий для сообщений о релизе
    /// </summary>
    public class DbReleaseMessageRepository : BaseRepository<DbReleaseMessage>, IDbReleaseMessageRepository
    {
        /// <summary>
        /// Создает новый экземпляр репозитория для сообщений о релизе
        /// с заданным контекстом базы данных
        /// </summary>
        /// <param name="dbContext">Экземпляр контекста базы данных</param>
        public DbReleaseMessageRepository(RocketContext dbContext)
            : base(dbContext)
        {
        }
    }
}