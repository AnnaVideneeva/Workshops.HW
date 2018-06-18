using System;

namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет информацию о конкретной серии сериала
    /// </summary>
    public class Episode
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор серии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает дату выхода серии (рус)
        /// </summary>
        public DateTime? ReleaseDateRu { get; set; }

        /// <summary>
        /// Возвращает или задает дату выхода серии (англ)
        /// </summary>
        public DateTime? ReleaseDateEn { get; set; }

        /// <summary>
        /// Возвращает или задает номер серии в сезоне
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Возвращает или задает название серии (рус)
        /// </summary>
        public string TitleRu { get; set; }

        /// <summary>
        /// Возвращает или задает название серии (англ)
        /// </summary>
        public string TitleEn { get; set; }

        /// <summary>
        /// Возвращает или задает продолжительность серии
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Ссылка на серию.
        /// </summary>
        public string UrlForEpisodeSource { get; set; }
    }
}