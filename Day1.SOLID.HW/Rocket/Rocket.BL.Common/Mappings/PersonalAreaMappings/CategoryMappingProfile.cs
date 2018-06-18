using AutoMapper;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.DAL.Common.DbModels.DbPersonalArea;

namespace Rocket.BL.Common.Mappings.PersonalAreaMappings
{
    /// <summary>
    /// Настройка маппинга между доменной моделью Category и моделью хранения DbCategory.
    /// </summary>
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, DbCategory>()
                .ForMember(dbc => dbc.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dbc => dbc.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dbc => dbc.Genres, c => c.MapFrom(src => src.Genres))
                .ReverseMap();
        }
    }
}