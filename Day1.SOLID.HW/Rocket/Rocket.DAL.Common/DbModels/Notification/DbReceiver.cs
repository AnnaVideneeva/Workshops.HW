using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.DbPersonalArea;

namespace Rocket.DAL.Common.DbModels.Notification
{
    /// <summary>
    /// Описывает модель хранения данных о пользователе,
    /// являющемся получателем сообщения
    /// </summary>
    public class DbReceiver
    {
        /// <summary>
        /// Возвращает или задает идентификационный номер получателя
        /// согласно модели <see cref="DbUserProfile"/>
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Возвращает или задает флаг подписки на email нотификацию
        /// </summary>
        public bool NotifyByEmail { get; set; }

        /// <summary>
        /// Возвращает или задает флаг подписки на push нотификацию
        /// </summary>
        public bool NotifyByPush { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию сообщений о платежах,
        /// получателем которых является пользователь
        /// </summary>
        public ICollection<DbUserBillingMessage> UserBillingMessages { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию сообщений произвольного содержания,
        /// получателем которых является пользователь
        /// </summary>
        public ICollection<DbCustomMessage> CustomMessages { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию объектов, содержащих 
        /// сводные данные о получателе и сообщении о релизе
        /// </summary>
        public ICollection<DbReceiversJoinReleases> ReceiversJoinReleases { get; set; }
    }
}