using System;
using AutoMapper;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.BL.Common.Models.Subscription;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    /// <summary>
    /// Профиль сопоставления доменной модели музыкального релиза с моделью хранения данных музыки
    /// </summary>
    public class MusicMappingProfile : Profile
    {
        public MusicMappingProfile()
        {
            CreateMap<Music, DbMusic>()
                .IncludeBase<Subscribable, SubscribableEntity>()
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.PosterImagePath, opt => opt.MapFrom(src => src.PosterImagePath))
                .ForMember(dest => dest.PosterImageUrl, opt => opt.MapFrom(src => src.PosterImageUrl))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Artist))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration.TotalSeconds))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dest => dest.MusicTracks, opt => opt.MapFrom(src => src.MusicTracks))
                .ForMember(dest => dest.Musicians, opt => opt.MapFrom(src => src.Musicians))
                .ReverseMap()
                .ForMember(dest => dest.Duration, opt => opt.ResolveUsing(src => TimeSpan.FromSeconds(src.Duration)));
        }
    }
}