using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Common.Repositories.Notification
{
    /// <summary>
    /// Представляет интерфейс репозитория для сообщений о релизе
    /// </summary>
    public interface IDbReleaseMessageRepository : IBaseRepository<DbReleaseMessage>
    {
    }
}