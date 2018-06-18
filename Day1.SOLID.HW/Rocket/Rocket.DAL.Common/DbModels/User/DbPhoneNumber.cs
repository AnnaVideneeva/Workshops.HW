using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.User
{
    /// <summary>
    /// Представляет модель хранения данных о телефонных номерах дополнительной информации пользователя.
    /// </summary>
    public class DbPhoneNumber
    {
        /// <summary>
        /// Задает или возвращает уникальный идентификатор телефонного номера дополнительной информации пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Задает или возвращает телефонный номер дополнительной информации пользователя.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Задает или возвращает коллекцию дополнительной информации пользователя,
        /// к которой относится этот телефонный номер.
        /// </summary>
        public ICollection<DbUserDetail> DbUserDetails { get; set; }
    }
}