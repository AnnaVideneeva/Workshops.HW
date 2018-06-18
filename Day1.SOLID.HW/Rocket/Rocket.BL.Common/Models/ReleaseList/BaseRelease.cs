using System;

namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет базовый тип для доменных моделей релизов
    /// (фильмов, серий, музыкальных альбомов)
    /// </summary>
    public abstract class BaseRelease
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор релиза
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает дату выхода релиза
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Возвращает или задает название релиза
        /// </summary>
        public string Title { get; set; }
    }
}