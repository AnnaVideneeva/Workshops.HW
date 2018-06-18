using System;
using System.Collections.Generic;

namespace Rocket.BL.Common.Models.Notification
{
    /// <summary>
    /// Описывает релиз сериала для целей нотификации
    /// </summary>
    public class EpisodeNotification
    {
        /// <summary>
        /// Возвращает или задает коллекцию получателей сообщений
        /// </summary>
        public ICollection<Receiver> Receivers { get; set; }

        /// <summary>
        /// Возвращает или задает название сериала
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает порядковый номер сезона
        /// </summary>
        public int SeasonNumber { get; set; }

        /// <summary>
        /// Возвращает или задает номер серии в сезоне
        /// </summary>
        public int EpisodeNumber { get; set; }

        /// <summary>
        /// Возвращает или задает дату выхода серии
        /// </summary>
        public DateTime ReleaseDate { get; set; }
    }
}