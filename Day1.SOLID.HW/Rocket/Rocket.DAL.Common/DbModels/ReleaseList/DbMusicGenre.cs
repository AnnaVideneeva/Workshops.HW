using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.DAL.Common.DbModels.ReleaseList
{
    /// <summary>
    /// Представляет модель хранения данных о музыкальных жанрах
    /// </summary>
    public class DbMusicGenre : SubscribableEntity
    {
        /// <summary>
        /// Возвращает или задает название музыкального жанра
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию музыкальных релизов,
        /// которые относятся к этому жанру
        /// </summary>
        public ICollection<DbMusic> DbMusics { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию пользователей, подписанных на этот жанр
        /// </summary>
        public ICollection<DbUserProfile> DbAuthorisedUsers { get; set; }
    }
}