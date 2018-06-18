using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Common.DbModels.ReleaseList
{
    /// <summary>
    /// Представляет модель хранения данных о фильмах
    /// </summary>
    public class DbFilm : DbBaseRelease
    {
        /// <summary>
        /// Возвращает или задает относительный путь
        /// от корневой папки приложения к файлу изображения постера фильма
        /// </summary>
        public string PosterImagePath { get; set; }

        /// <summary>
        /// Возвращает или задает продолжительность фильма
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Возвращает или задает краткое описание фильма
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Возвращает или задает ссылку на трейлер фильма
        /// </summary>
        public string TrailerLink { get; set; }
    }
}