using System;
using System.Collections.Generic;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Common.Models.Notification
{
    /// <summary>
    /// Описывает музыкальный релиз для целей нотификации
    /// </summary>
    public class MusicNotification
    {
        /// <summary>
        /// Возвращает или задает коллекцию получателей сообщений
        /// </summary>
        public ICollection<Receiver> Receivers { get; set; }

        /// <summary>
        /// Возвращает или задает название музыкального релиза
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает дату выхода музыкального релиза
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Возвращает или задает исполнителей музыкального релиза
        /// </summary>
        public IList<Musician> Musicians { get; set; }
    }
}