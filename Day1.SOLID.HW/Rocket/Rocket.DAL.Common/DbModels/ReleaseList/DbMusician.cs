using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.DAL.Common.DbModels.ReleaseList
{
    /// <summary>
    /// Представляет модель хранения данных музыкальных исполнителей
    /// </summary>
    public class DbMusician : SubscribableEntity
    {
        /// <summary>
        /// Возвращает или задает полное имя музыкального исполнителя (название группы)
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию музыкальных релизов,
        /// которые относятся к данному исполнителю
        /// </summary>
        public ICollection<DbMusic> Musics { get; set; }
    }
}