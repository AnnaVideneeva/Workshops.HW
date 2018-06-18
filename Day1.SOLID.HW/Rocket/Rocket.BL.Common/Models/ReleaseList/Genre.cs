using Rocket.BL.Common.Models.Subscription;

namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет информацию о жанре фильма или сериала
    /// </summary>
    public class Genre : Subscribable
    {
        /// <summary>
        /// Возвращает или задает название жанра
        /// </summary>
        public string Name { get; set; }
    }
}