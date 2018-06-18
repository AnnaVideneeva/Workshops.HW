using AutoMapper;
using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.BL.Common.Models.Subscription;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    /// <summary>
    /// Профиль сопоставления доменной модели и Dto моделей человека
    /// с моделью хранения данных человека
    /// </summary>
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonEntity>()
                .IncludeBase<Subscribable, SubscribableEntity>()
                .ReverseMap();

            CreateMap<PersonEntity, PersonMinimalDto>()
                .ForMember(dest => dest.PersonType, opt => opt.MapFrom(src => src.PersonType.Name));
        }
    }
}