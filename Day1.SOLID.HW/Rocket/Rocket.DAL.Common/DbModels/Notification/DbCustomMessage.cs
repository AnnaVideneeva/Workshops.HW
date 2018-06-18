using System;

namespace Rocket.DAL.Common.DbModels.Notification
{
    /// <summary>
    /// Описывает модель хранения данных о сообщении произвольного содержания
    /// </summary>
    public class DbCustomMessage
    {
        /// <summary>
        /// Возвращает или задает идентификационный номер сообщения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает получателя сообщения
        /// </summary>
        public DbReceiver Receiver { get; set; }

        /// <summary>
        /// Возвращает или задает идентификационный номер получателя сообщения
        /// </summary>
        public int ReceiverId { get; set; }

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

        /// <summary>
        /// Возвращает или задает флаг просмотра пользователем
        /// push нотификации
        /// </summary>
        public bool Viewed { get; set; }

        /// <summary>
        /// Возвращает или задает время создания сообщения
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}