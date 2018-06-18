using System;
using System.Collections.Generic;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Common.Models.User
{
    /// <summary>
    /// Детальная информация о пользователе.
    /// </summary>
    public class UserDetail
    {
        /// <summary>
        /// Уникальный идентификатор дополнительной информации пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает необходимость подтверждения регистрации
        /// путем активации Email.
        /// </summary>
        public bool ActivationNeeded { get; set; }

        /// <summary>
        /// Задает или возвращает гражданство пользователя.
        /// </summary>
        public Country Sitizenship { get; set; }

        /// <summary>
        /// Задает или возвращает язык пользователя.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Задает или возвращает дату рождения пользователя.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Задает или возвращает пол пользователя.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Задает или возвращает сведения о том, как обращаться к пользователю.
        /// </summary>
        public HowToCall HowToCall { get; set; }

        /// <summary>
        /// Задает или возвращает коллекцию телефонных номеров пользователя.
        /// </summary>
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Задает или возвращает коллекцию Email.
        /// </summary>
        public ICollection<EmailAddress> EMailAddresses { get; set; }

        /// <summary>
        /// Возвращает или задает почтовый адрес пользователя.
        /// </summary>
        public Address MailAddress { get; set; }
    }
}