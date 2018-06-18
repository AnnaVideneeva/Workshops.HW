using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.Parser
{
    /// <summary>
    /// Сущность модели сезона сериала.
    /// </summary>
    public class SeasonEntity
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер сезона.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Url изображения постера сезона.
        /// </summary>
        public string PosterImageUrl { get; set; }

        /// <summary>
        /// Список серий сезона.
        /// </summary>
        public ICollection<EpisodeEntity> ListEpisode { get; set; }

        /// <summary>
        /// Id cериала к которому относится этот сезон.
        /// </summary>
        public int TvSeriesId { get; set; }

        public TvSeriasEntity TvSeries { get; set; }
    }
}
