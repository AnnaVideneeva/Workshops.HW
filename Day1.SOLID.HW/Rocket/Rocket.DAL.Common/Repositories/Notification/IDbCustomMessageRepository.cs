using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Common.Repositories.Notification
{
    /// <summary>
    /// Представляет интерфейс репозитория для сообщений произвольного содержания
    /// </summary>
    public interface IDbCustomMessageRepository : IBaseRepository<DbCustomMessage>
    {
    }
}