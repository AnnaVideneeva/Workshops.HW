using System.Collections.Generic;

namespace Rocket.DAL.Common.DbModels.Parser
{
    public class PersonTypeEntity
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public ICollection<PersonEntity> ListPerson { get; set; }
    }
}
