using System;

namespace Rocket.BL.Common.Models.ReleaseList
{
    public class MusicTrack
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор трека
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает номер трека
        /// </summary>
        //public int Number { get; set; }

        /// <summary>
        /// Возвращает или задает название музыкального трека
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает продолжительность музыкального трека
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}