using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rocket.BL.Common.Models.Subscription;

namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет информацию о конкретном сериале
    /// </summary>
    public class TVSeries : Subscribable
    {
        /// <summary>
        /// Возвращает или задает название сериала (рус)
        /// </summary>
        public string TitleRu { get; set; }

        /// <summary>
        /// Возвращает или задает название сериала (англ)
        /// </summary>
        public string TitleEn { get; set; }

        /// <summary>
        /// Возвращает или задает абсолютный Url
        /// к файлу изображения постера фильма
        /// </summary>
        public string PosterImageUrl { get; set; }

        /// <summary>
        /// Рейтинг сериала на Lostfilm.
        /// </summary>
        public double LostfilmRate { get; set; }

        /// <summary>
        /// Рейтинг сериала на IMDb.
        /// </summary>
        public double RateImDb { get; set; }

        /// <summary>
        /// Ссылка на официальный сайт.
        /// </summary>
        public string UrlToOfficialSite { get; set; }

        /// <summary>
        /// Текущий статус сериала.
        /// </summary>
        public string CurrentStatus { get; set; }

        /// <summary>
        /// Теливизионный канал на котором показывают сериал.
        /// </summary>
        public string TvSerialCanal { get; set; }

        /// <summary>
        /// Год начала показа сериала.
        /// </summary>
        public string TvSerialYearStart { get; set; }

        /// <summary>
        /// Возвращает или задает краткое описание сериала
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Ссылка на адрес загрузки.
        /// </summary>
        public string UrlToSource { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию актёров, которые снялись в сериале
        /// </summary>
        public ICollection<Person> ListPerson { get; set; } = new Collection<Person>();

        /// <summary>
        /// Возвращает или задает коллекцию жанров, к которым относится сериал
        /// </summary>
        public ICollection<Genre> Genres { get; set; } = new Collection<Genre>();
        
        /// <summary>
        /// Возвращает или задает коллекцию сезонов сериала
        /// </summary>
        public ICollection<Season> ListSeasons { get; set; } = new Collection<Season>();
    }
}