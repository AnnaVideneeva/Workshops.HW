using System;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.DAL.Common.DbModels.Parser
{
    /// <summary>
    /// Сущность модели серии.
    /// </summary>
    public class EpisodeEntity : SubscribableEntity
    {
        /// <summary>
        /// Дата выхода серии(рус).
        /// </summary>
        public DateTime? ReleaseDateRu { get; set; }

        /// <summary>
        /// Дата выхода серии(англ).
        /// </summary>
        public DateTime? ReleaseDateEn { get; set; }

        /// <summary>
        /// Номер серии в сезоне.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Название серии(рус).
        /// </summary>
        public string TitleRu { get; set; }

        /// <summary>
        /// Название серии(англ).
        /// </summary>
        public string TitleEn { get; set; }

        /// <summary>
        /// Продолжительность серии.
        /// </summary>
        public double DurationInMinutes { get; set; }

        /// <summary>
        /// Ссылка на серию.
        /// </summary>
        public string UrlForEpisodeSource { get; set; }

        /// <summary>
        /// Id сезона к которому относится эта серия.
        /// </summary>
        public int SeasonId { get; set; }

        /// <summary>
        /// Сезон к которому относится эта серия.
        /// </summary>
        public SeasonEntity Season { get; set; }
    }
}
