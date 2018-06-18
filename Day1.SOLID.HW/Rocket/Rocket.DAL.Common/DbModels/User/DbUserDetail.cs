using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rocket.DAL.Common.DbModels.ReleaseList;

namespace Rocket.DAL.Common.DbModels.User
{
    /// <summary>
    /// Представляет модель хранения детальных данных о пользователе.
    /// </summary>
    public class DbUserDetail
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор дополнительной информации пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает необходимость подтверждения регистрации
        /// путем активации Email.
        /// </summary>
        public bool? ActivationNeeded { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор страны гражданства пользователя,
        /// к которому относится эта дополнительная информация.
        /// </summary>
        public int? SitizenshipId { get; set; }

        /// <summary>
        /// Задает или возвращает гражданство пользователя.
        /// </summary>
        public virtual DbCountry Sitizenship { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор языка (общения) пользователя,
        /// к которому относится эта дополнительная информация.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Задает или возвращает язык пользователя.
        /// </summary>
        public virtual DbLanguage Language { get; set; }

        /// <summary>
        /// Задает или возвращает дату рождения пользователя.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор половой принадлежности пользователя,
        /// к которому относится эта дополнительная информация.
        /// </summary>
        public int? GenderId { get; set; }

        /// <summary>
        /// Задает или возвращает пол пользователя.
        /// </summary>
        public virtual DbGender Gender { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор сведений о том, как обращаться к пользователю.
        /// к которому относится эта дополнительная информация.
        /// </summary>
        public int? HowToCallId { get; set; }

        /// <summary>
        /// Задает или возвращает сведения о том, как обращаться к пользователю.
        /// </summary>
        public virtual DbHowToCall HowToCall { get; set; }

        /// <summary>
        /// Задает или возвращает коллекцию телефонных номеров пользователя.
        /// </summary>
        public virtual ICollection<DbPhoneNumber> PhoneNumbers { get; set; } = new Collection<DbPhoneNumber>();

        /// <summary>
        /// Задает или возвращает коллекцию Email.
        /// </summary>
        public virtual ICollection<DbEmailAddress> EMailAddresses { get; set; } = new Collection<DbEmailAddress>();

        /// <summary>
        /// Возвращает или задает идентификатор почтового адреса пользователя.
        /// к которому относится эта дополнительная информация.
        /// </summary>
        public int? MailAddressId { get; set; }

        /// <summary>
        /// Возвращает или задает почтовый адрес пользователя.
        /// </summary>
        public virtual DbAddress MailAddress { get; set; }

        /// <summary>
        /// Возвращает или задает пользователя,
        /// К которому относится эта дополнительная информация.
        /// </summary>
        public DbUser User { get; set; }
    }
}