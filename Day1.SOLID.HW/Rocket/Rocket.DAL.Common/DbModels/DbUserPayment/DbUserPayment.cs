using Rocket.DAL.Common.DbModels.User;
using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels
{
    /// <summary>
    /// Представляет модель хранения данных о платеже
    /// </summary>
    public class DbUserPayment
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор платежа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает id пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Возвращает или задает имя человека, указанное при проведении платежа
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Возвращает или задает фамилию человека, указанную при проведении платежа
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Возвращает или задает email, указанный при проведении платежа
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Возвращает или задает валюту
        /// </summary>
        public string Currentcy { get; set; }

        /// <summary>
        /// Возвращает или задает ID платежа, который выдан платежной системой
        /// </summary>
        public string PaymentID { get; set; }

        /// <summary>
        /// Возвращает или задает сумму платежа
        /// </summary>
        public decimal Summ { get; set; }

        /// <summary>
        /// Возвращает или задает результат платежа
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Возвращает или задает пользовательскую строку платежа
        /// </summary>
        public string CustomString { get; set; }
    }
}
