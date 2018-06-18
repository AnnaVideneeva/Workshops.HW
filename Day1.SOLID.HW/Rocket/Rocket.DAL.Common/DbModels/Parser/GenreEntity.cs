using System.Collections.Generic;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.DAL.Common.DbModels.Parser
{
    /// <summary>
    /// Сущность модели жанра.
    /// </summary>
    public class GenreEntity : SubscribableEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public int CategoryCode { get; set; }

        public CategoryEntity Category { get; set; }

        public List<TvSeriasEntity> ListTvSerias { get; set; }

        public List<DbUserProfile> ListAuthorisedUser { get; set; }
    }
}
