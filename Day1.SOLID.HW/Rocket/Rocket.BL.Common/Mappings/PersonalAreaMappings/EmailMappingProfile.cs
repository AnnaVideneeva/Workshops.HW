using AutoMapper;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.DAL.Common.DbModels.DbPersonalArea;

namespace Rocket.BL.Common.Mappings.PersonalAreaMappings
{
    /// <summary>
    /// Настройка маппинга между доменной моделью Email и моделью хранения DbEmail.
    /// </summary>
    public class EmailMappingProfile : Profile
    {
        public EmailMappingProfile()
        {
            CreateMap<Email, DbEmail>()
                .ForMember(dbe => dbe.Id, e => e.MapFrom(src => src.Id))
                .ForMember(dbe => dbe.Name, e => e.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
