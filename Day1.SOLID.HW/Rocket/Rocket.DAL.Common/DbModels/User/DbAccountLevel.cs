using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.User
{
    /// <summary>
    /// Представляет модель хранения данных об уровне аккаунта пользователя.
    /// </summary>
    public class DbAccountLevel
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор уровня аккаунта пользователя.
        /// </summary>
        /// <value>Уникальный идентификатор уровня аккаунта пользователя.</value>>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает название уровня аккаунта пользователя.
        /// </summary>
        /// <value>Название уровня аккаунта пользователя.</value>>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию пользователей,
        /// в которых указан данный уровень пользователя.
        /// </summary>
        /// <value>Коллекция пользователей с данным уровнем аккаунта пользователя.</value>>
        public ICollection<DbUser> DbUsers { get; set; }
    }
}