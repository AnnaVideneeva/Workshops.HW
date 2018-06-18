using AutoMapper;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    public class PersonTypeMappingProfile : Profile
    {
        public PersonTypeMappingProfile()
        {
            CreateMap<PersonType, PersonTypeEntity>().ReverseMap();
        }
    }
}
