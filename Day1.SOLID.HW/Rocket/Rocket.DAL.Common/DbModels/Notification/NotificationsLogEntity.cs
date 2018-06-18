using System;
using Rocket.DAL.Common.Enums;

namespace Rocket.DAL.Common.DbModels.Notification
{
    /// <summary>
    /// Лог нотификации
    /// </summary>
    public class NotificationsLogEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id релиза
        /// </summary>
        public int ReleaseId { get; set; }

        /// <summary>
        /// Дата и время создания
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
    }
}
