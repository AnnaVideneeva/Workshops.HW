using AutoMapper;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.DAL.Common.DbModels.DbPersonalArea;

namespace Rocket.BL.Common.Mappings.PersonalAreaMappings
{
    /// <summary>
    /// Настройка маппинга между доменной моделью Genre и моделью хранения DbGenre.
    /// </summary>
    public class GenreMappingProfile : Profile
    {
        public GenreMappingProfile()
        {
            CreateMap<Genre, DbGenre>()
                .ForMember(dbg => dbg.Id, g => g.MapFrom(src => src.Id))
                .ForMember(dbg => dbg.Name, g => g.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}