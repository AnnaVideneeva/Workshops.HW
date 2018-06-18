using AutoMapper;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.BL.Common.Models.Subscription;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    /// <summary>
    /// Профиль сопоставления доменной модели музыкальных жанров с моделью хранения данных музыкальных жанров
    /// </summary>
    public class MusicGenreMappingProfile : Profile
    {
        public MusicGenreMappingProfile()
        {
            CreateMap<MusicGenre, DbMusicGenre>()
                .IncludeBase<Subscribable, SubscribableEntity>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}