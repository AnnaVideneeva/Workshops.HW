using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.DAL.Common.DbModels.Parser
{
    /// <summary>
    /// Сущность модели хранения данных о сериалах
    /// </summary>
    public class TvSeriasEntity : SubscribableEntity
    {
        /// <summary>
        /// Название сериала(рус).
        /// </summary>
        public string TitleRu { get; set; }

        /// <summary>
        /// Название сериала(англ).
        /// </summary>
        public string TitleEn { get; set; }

        /// <summary>
        /// Url изображения постера сериала.
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
        /// Краткое описание сериала.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Ссылка на адрес загрузки.
        /// </summary>
        public string UrlToSource { get; set; }

        /// <summary>
        /// Дата премьеры прописью для последующего парсинга.
        /// </summary>
        public string PremiereDateForParse { get; set; }

        /// <summary>
        /// Список всех персон.
        /// </summary>
        public ICollection<PersonEntity> ListPerson { get; set; } = new List<PersonEntity>();

        ///// <summary>
        ///// Список актеров.
        ///// </summary>
        //public ICollection<PersonEntity> ListActor
        //{
        //    get { return ListPerson.Where(i => i.PersonTypeCode == (int)PersonType.Actor).ToList(); }
        //}

        ///// <summary>
        ///// Список режисеров.
        ///// </summary>
        //public ICollection<PersonEntity> ListDirector
        //{
        //    get { return ListPerson.Where(i => i.PersonTypeCode == (int)PersonType.Director).ToList(); }
        //}

        ///// <summary>
        ///// Список продюсеров.
        ///// </summary>
        //public ICollection<PersonEntity> ListProducer
        //{
        //    get { return ListPerson.Where(i => i.PersonTypeCode == (int)PersonType.Producer).ToList(); }
        //}

        ///// <summary>
        ///// Список сценаристов.
        ///// </summary>
        //public ICollection<PersonEntity> ListWriter
        //{
        //    get { return ListPerson.Where(i => i.PersonTypeCode == (int)PersonType.Writer).ToList(); }
        //}

        /// <summary>
        /// Возвращает или задает коллекцию жанров, к которым относится сериал
        /// </summary>
        public ICollection<GenreEntity> ListGenreEntity { get; set; } = new List<GenreEntity>();

        /// <summary>
        /// Возвращает или задает коллекцию сезонов сериала
        /// </summary>
        public ICollection<SeasonEntity> ListSeasons { get; set; } = new List<SeasonEntity>();
    }
}
