using System;

namespace Rocket.BL.Common.Models.Notification
{
    /// <summary>
    /// Описывает сообщение с данными о совершенных
    /// пользователем либо гостем платежах на сайте
    /// (покупка премиум аккаунта, донат)
    /// </summary>
    public class BillingNotification
    {
        /// <summary>
        /// Возвращает или задает получателя сообщения
        /// </summary>
        public Receiver Receiver { get; set; }

        /// <summary>
        /// Возвращает или задает оплаченную сумму
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Возвращает или задает валюту платежа
        /// </summary>
        public string Currency { get; set; }
    }
}