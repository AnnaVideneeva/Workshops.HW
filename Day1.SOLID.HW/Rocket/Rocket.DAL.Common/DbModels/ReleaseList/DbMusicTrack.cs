using System;

namespace Rocket.DAL.Common.DbModels.ReleaseList
{
    /// <summary>
    /// Представляет модель хранения данных о треках музыкального релиза
    /// </summary>
    public class DbMusicTrack
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор трека
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает название музыкального трека
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает продолжительность музыкального трека
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор музыкального релиза,
        /// к которому относится трек
        /// </summary>
        public int DbMusicId { get; set; }

        /// <summary>
        /// Возвращает музыкальный релиз,
        /// который относятся к этому треку
        /// </summary>
        public DbMusic DbMusic { get; set; }
    }
}