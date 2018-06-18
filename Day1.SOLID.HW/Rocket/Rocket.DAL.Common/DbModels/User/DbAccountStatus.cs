using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.User
{
    /// <summary>
    /// Представляет модель хранения данных о статусе аккаунта.
    /// </summary>
    public class DbAccountStatus
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор статуса аккаунта пользователя.
        /// </summary>
        /// <value>Уникальный идентификатор статуса аккаунта пользователя.</value>>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает название статуса аккаунта
        /// (активирован, не активирован, деактивирован, забанен).
        /// </summary>
        /// <value>Название идентификатора статуса аккаунта пользователя.</value>>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию пользователей,
        /// в которых указан данный статус пользователя.
        /// </summary>
        /// <value>Коллекция пользователей, в которых указан данный статус пользователя.</value>>
        public ICollection<DbUser> DbUsers { get; set; }
    }
}