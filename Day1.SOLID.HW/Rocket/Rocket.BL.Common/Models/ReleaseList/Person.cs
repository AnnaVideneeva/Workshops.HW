using Rocket.BL.Common.Models.Subscription;

namespace Rocket.BL.Common.Models.ReleaseList
{
    /// <summary>
    /// Представляет информацию о человеке (режиссере, актёре)
    /// </summary>
    public class Person : Subscribable
    {
        /// <summary>
        /// Возвращает или задает имя и фамилию (полное имя) человека
        /// </summary>
        public string FullNameRu { get; set; }

        /// <summary>
        /// Полное имя человека(англ).
        /// </summary>
        public string FullNameEn { get; set; }

        /// <summary>
        /// Lostfilm-ссылка на личную сраницу.
        /// </summary>
        public string LostfilmPersonalPageUrl { get; set; }

        /// <summary>
        /// Фото превью человека.
        /// </summary>
        public string PhotoThumbnailUrl { get; set; }

        /// <summary>
        /// Возвращает или задает тип человека (актёр, режиссёр)
        /// </summary>
        public PersonType PersonType { get; set; }
    }
}