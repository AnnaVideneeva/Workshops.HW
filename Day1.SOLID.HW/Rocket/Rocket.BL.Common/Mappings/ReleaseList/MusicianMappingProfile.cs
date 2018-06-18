using AutoMapper;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.BL.Common.Models.Subscription;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    /// <summary>
    /// Профиль сопоставления доменной модели музыкальных исполнителей с моделью хранения данных музыкальных исполнителей
    /// </summary>
    public class MusicianMappingProfile : Profile
    {
        public MusicianMappingProfile()
        {
            CreateMap<Musician, DbMusician>()
                .IncludeBase<Subscribable, SubscribableEntity>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ReverseMap();
        }
    }
}