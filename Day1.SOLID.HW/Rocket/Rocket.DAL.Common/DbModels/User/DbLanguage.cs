using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.User
{
    /// <summary>
    /// Представляет модель хранения данных о языке дополнительной информации пользователя.
    /// </summary>
    public class DbLanguage
    {
        /// <summary>
        /// Задает или возвращает уникальный идентификатор языка дополнительной информации пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Задает или возвращает название языка дополнительной информации пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задает или возвращает коллекцию дополнительной информации пользователя,
        /// к которой относится этот язык.
        /// </summary>
        public ICollection<DbUserDetail> DbUserDetails { get; set; }
    }
}