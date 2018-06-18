using System.Collections.Generic;
using Rocket.BL.Common.Models.UserRoles;

namespace Rocket.BL.Common.Models.User
{
    /// <summary>
    /// Представляет информацию о пользователе.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор пользователя.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Возвращает или задает логин пользователя.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Возвращает или задает пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Возвращает или задает статус аккаунта
        /// (активирован, не активирован, деактивирован, забанен и так далее).
        /// </summary>
        public AccountStatus AccountStatus { get; set; }

        /// <summary>
        /// Возвращает или задает уровень пользователя
        /// (пока что это - обычный и премиум пользователь).
        /// </summary>
        public AccountLevel AccountLevel { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию ролей пользователя.
        /// </summary>
        public ICollection<Role> Roles { get; set; }

        /// <summary>
        /// Детальная информация пользователя.
        /// </summary>
        public UserDetail UserDetail { get; set; }
    }
}