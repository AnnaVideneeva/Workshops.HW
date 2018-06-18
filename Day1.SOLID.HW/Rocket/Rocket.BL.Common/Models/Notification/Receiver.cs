using System.Collections.Generic;

namespace Rocket.BL.Common.Models.Notification
{
    /// <summary>
    /// Описывает гостя либо пользователя, 
    /// являющегося получателем сообщения
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Возвращает или задает имя гостя или пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Возвращает или задает фамилию пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию email адресов гостя или пользователя
        /// </summary>
        public ICollection<string> Emails { get; set; }
    }
}