using System;

namespace Rocket.DAL.Common.DbModels.Notification
{
    /// <summary>
    /// Описывает модель хранения данных сообщения с информацией о совершенном гостем донате
    /// </summary>
    public class DbGuestBillingMessage
    {
        /// <summary>
        /// Возвращает или задает идентификационный номер сообщения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает имя гостя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает email адрес гостя
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Возвращает или задает оплаченную сумму
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Возвращает или задает время создания сообщения
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}