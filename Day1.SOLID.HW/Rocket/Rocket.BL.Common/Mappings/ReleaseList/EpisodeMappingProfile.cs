using System;
using AutoMapper;
using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    /// <summary>
    /// Профиль сопоставления доменной модели и Dto моделей серии
    /// с моделью хранения данных серии
    /// </summary>
    public class EpisodeMappingProfile : Profile
    {
        public EpisodeMappingProfile()
        {
            CreateMap<Episode, EpisodeEntity>()
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.Duration.TotalMinutes))
                .ReverseMap()
                .ForMember(
                    dest => dest.Duration,
                    opt => opt.ResolveUsing(src => TimeSpan.FromMinutes(src.DurationInMinutes)));

            CreateMap<EpisodeEntity, EpisodeMinimalDto>()
                .ForMember(dest => dest.SeasonNumber, opt => opt.MapFrom(src => src.Season.Number));

            CreateMap<EpisodeEntity, EpisodeDto>()
                .IncludeBase<EpisodeEntity, EpisodeMinimalDto>()
                .ForMember(dest => dest.TvSeriesId, opt => opt.MapFrom(src => src.Season.TvSeriesId))
                .ForMember(dest => dest.TvSeriesTitleEn, opt => opt.MapFrom(src => src.Season.TvSeries.TitleEn))
                .ForMember(dest => dest.TvSeriesTitleRu, opt => opt.MapFrom(src => src.Season.TvSeries.TitleRu))
                .ForMember(
                    dest => dest.PosterImageUrl,
                    opt => opt.ResolveUsing(src =>
                        !string.IsNullOrWhiteSpace(src.Season.TvSeries.PosterImageUrl)
                            ? src.Season.TvSeries.PosterImageUrl
                            : src.Season.PosterImageUrl));

            CreateMap<EpisodeEntity, EpisodeFullDto>()
                .IncludeBase<EpisodeEntity, EpisodeDto>();
        }
    }
}