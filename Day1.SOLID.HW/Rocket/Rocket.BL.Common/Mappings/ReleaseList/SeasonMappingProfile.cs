using AutoMapper;
using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    /// <summary>
    /// Профиль сопоставления доменной модели Dto моделей сезона
    /// с моделью хранения данных сезона
    /// </summary>
    public class SeasonMappingProfile : Profile
    {
        public SeasonMappingProfile()
        {
            CreateMap<Season, SeasonEntity>().ReverseMap();

            CreateMap<SeasonEntity, SeasonDto>();
        }
    }
}