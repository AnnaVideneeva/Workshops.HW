using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет информацию о конкретном фильме
    /// </summary>
    public class Film : BaseRelease
    {
        /// <summary>
        /// Возвращает или задает относительный путь
        /// от корневой папки приложения к файлу изображения постера фильма
        /// </summary>
        public string PosterImagePath { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию режиссеров, которые сняли фильм
        /// </summary>
        public ICollection<Person> Directors { get; set; } = new Collection<Person>();

        /// <summary>
        /// Возвращает или задает коллекцию актёров, которые снялись в фильме
        /// </summary>
        public ICollection<Person> Cast { get; set; } = new Collection<Person>();

        /// <summary>
        /// Возвращает или задает коллекцию жанров, к которым относится фильм
        /// </summary>
        public ICollection<Genre> Genres { get; set; } = new Collection<Genre>();

        /// <summary>
        /// Возвращает или задает коллекцию стран, которые участвовали в создании фильма
        /// </summary>
        public ICollection<Country> Countries { get; set; } = new Collection<Country>();

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