using Rocket.BL.Common.Models.Subscription;

namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет информацию о жанре музыкального релиза
    /// </summary>
    public class MusicGenre : Subscribable
    {
        /// <summary>
        /// Возвращает или задает название музыкального жанра
        /// </summary>
        public string Name { get; set; }
    }
}