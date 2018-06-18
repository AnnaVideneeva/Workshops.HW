using AutoMapper;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.DAL.Common.DbModels.ReleaseList;

namespace Rocket.BL.Common.Mappings.ReleaseList
{
    /// <summary>
    /// Профиль сопоставления доменной модели фильма с моделью хранения данных фильма
    /// </summary>
    public class FilmMappingProfile : Profile
    {
        public FilmMappingProfile()
        {
            CreateMap<Film, DbFilm>()
                .IncludeBase<BaseRelease, DbBaseRelease>()
                .ReverseMap();
        }
    }
}