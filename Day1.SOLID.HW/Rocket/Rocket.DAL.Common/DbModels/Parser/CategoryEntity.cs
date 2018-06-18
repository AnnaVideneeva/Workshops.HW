using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.Parser
{
    public class CategoryEntity
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public ICollection<GenreEntity> ListGenre { get; set; }
    }
}
