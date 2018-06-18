using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.User
{
    /// <summary>
    /// Представляет модель хранения пола дополнительной информации пользователя.
    /// </summary>
    public class DbGender
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор пола дополнительной информации пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает пол дополнительной информации пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задает или возвращает коллекцию дополнительной информации пользователя,
        /// к которой относится этот пол.
        /// </summary>
        public ICollection<DbUserDetail> DbUserDetails { get; set; }
    }
}