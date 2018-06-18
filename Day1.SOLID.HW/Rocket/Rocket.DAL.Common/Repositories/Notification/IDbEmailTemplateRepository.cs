using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Common.Repositories.Notification
{
    /// <summary>
    /// Представляет интерфейс репозитория для шаблонов email сообщений
    /// </summary>
    public interface IDbEmailTemplateRepository : IBaseRepository<DbEmailTemplate>
    {
    }
}