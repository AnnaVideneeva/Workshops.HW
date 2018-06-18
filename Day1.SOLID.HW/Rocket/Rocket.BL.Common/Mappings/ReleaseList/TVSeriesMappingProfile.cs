using AutoMapper;
using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.BL.Common.Models.Subscription;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    /// <summary>
    /// Профиль сопоставления доменной модели и Dto моделей сериала с моделью хранения данных сериала
    /// </summary>
    public class TVSeriesMappingProfile : Profile
    {
        public TVSeriesMappingProfile()
        {
            CreateMap<TVSeries, TvSeriasEntity>()
                .IncludeBase<Subscribable, SubscribableEntity>()
                .ForMember(dest => dest.ListGenreEntity, opt => opt.MapFrom(src => src.Genres))
                .ReverseMap();

            CreateMap<TvSeriasEntity, TvSeriesMinimalDto>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.ListGenreEntity));

            CreateMap<TvSeriasEntity, TvSeriesFullDto>()
                .IncludeBase<TvSeriasEntity, TvSeriesMinimalDto>()
                .ForMember(dest => dest.Persons, opt => opt.MapFrom(src => src.ListPerson))
                .ForMember(dest => dest.Seasons, opt => opt.MapFrom(src => src.ListSeasons));

            CreateMap<TvSeriasEntity, TvSeriesDetailsDto>()
                .ForMember(dest => dest.TvSeriesId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TvSeriesTitleEn, opt => opt.MapFrom(src => src.TitleEn))
                .ForMember(dest => dest.TvSeriesTitleRu, opt => opt.MapFrom(src => src.TitleRu));

            CreateMap<TvSeriasEntity, TvSeriesSeasonsDto>()
                .IncludeBase<TvSeriasEntity, TvSeriesDetailsDto>()
                .ForMember(dest => dest.Seasons, opt => opt.MapFrom(src => src.ListSeasons));

            CreateMap<TvSeriasEntity, TvSeriesPersonsDto>()
                .IncludeBase<TvSeriasEntity, TvSeriesDetailsDto>()
                .ForMember(dest => dest.Persons, opt => opt.MapFrom(src => src.ListPerson));
        }
    }
}