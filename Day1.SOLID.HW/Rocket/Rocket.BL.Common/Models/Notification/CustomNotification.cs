using System;

namespace Rocket.BL.Common.Models.Notification
{
    /// <summary>
    /// Описывает сообщение произвольного содержания
    /// </summary>
    public class CustomNotification
    {
        /// <summary>
        /// Возвращает или задает получателя сообщения
        /// </summary>
        public Receiver Receiver { get; set; }

        /// <summary>
        /// Возвращает или задает имя отправителя сообщения
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Возвращает или задает тему сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Возвращает или задает тело сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Возвращает или задает флаг тела сообщения в формате HTML
        /// </summary>
        public bool HtmlBody { get; set; }
    }
}