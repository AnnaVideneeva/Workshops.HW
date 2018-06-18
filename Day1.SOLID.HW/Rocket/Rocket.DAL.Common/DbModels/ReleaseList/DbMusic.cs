using System;
using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.DAL.Common.DbModels.ReleaseList
{
    /// <summary>
    /// Представляет модель хранения данных музыкального релиза
    /// </summary>
    public class DbMusic : SubscribableEntity
    {
        private ICollection<DbMusician> _dbMusicians;
        private ICollection<DbMusicGenre> _dbMusicGenres;
        private ICollection<DbMusicTrack> _dbMusicTracks;

        /// <summary>
        /// Возвращает или задает название музыкального релиза
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает дату выхода музыкального релиза
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Возвращает или задает относительный путь
        /// от корневой папки приложения к файлу изображения постера музыкального релиза
        /// </summary>
        public string PosterImagePath { get; set; }

        /// <summary>
        /// Url постера на сайте ресурса
        /// </summary>
        public string PosterImageUrl { get; set; }

        /// <summary>
        /// Возвращает или задает продолжительность музыкального релиза
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию жанров, к которым относится музыкальный релиз
        /// </summary>
        public ICollection<DbMusicGenre> Genres
        {
            get => _dbMusicGenres ?? (_dbMusicGenres = new List<DbMusicGenre>());
            set => _dbMusicGenres = value;
        }

        /// <summary>
        /// Возвращает или задает музыкальные треки которые относятся к релизу
        /// </summary>
        public ICollection<DbMusicTrack> MusicTracks
        {
            get => _dbMusicTracks ?? (_dbMusicTracks = new List<DbMusicTrack>());
            set => _dbMusicTracks = value;
        }

        /// <summary>
        /// Возвращает или задает исполнителей музыкального релиза
        /// </summary>
        public ICollection<DbMusician> Musicians
        {
            get => _dbMusicians ?? (_dbMusicians = new List<DbMusician>());
            set => _dbMusicians = value;
        }

        /// <summary>
        /// Исполнитель
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Тип релиза
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Источники релиза
        /// </summary>
        public ICollection<ResourceItemEntity> ResourceItems { get; set; }
    }
}
