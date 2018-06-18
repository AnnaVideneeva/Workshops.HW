using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.DAL.Common.DbModels.Parser
{
    /// <summary>
    /// Сущность модели человека (режиссере, актёре или музыканте).
    /// </summary>
    public class PersonEntity : SubscribableEntity
    {
        /// <summary>
        /// Полное имя человека(рус).
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

        public int PersonTypeCode { get; set; }

        public PersonTypeEntity PersonType { get; set; }

        public ICollection<TvSeriasEntity> ListTvSerias { get; set; }
    }
}
