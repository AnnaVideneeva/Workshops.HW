using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет информацию о конкретном сезоне сериала
    /// </summary>
    public class Season
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор сезона
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает порядковый номер сезона
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Возвращает или задает абсолютный Url
        /// к файлу изображения постера сезона
        /// </summary>
        public string PosterImageUrl { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию серий сезона
        /// </summary>
        public ICollection<Episode> ListEpisode { get; set; } = new Collection<Episode>();
    }
}