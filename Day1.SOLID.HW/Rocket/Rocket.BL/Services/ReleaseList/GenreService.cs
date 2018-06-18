using AutoMapper;
using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Services.ReleaseList;
using Rocket.DAL.Common.UoW;
using System.Collections.Generic;

namespace Rocket.BL.Services.ReleaseList
{
    public class GenreService : BaseService, IGenreService
    {
        public GenreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<GenreDto> GetTvSeriesGenres()
        {
            return Mapper.Map<IEnumerable<GenreDto>>(_unitOfWork.GenreRepository.Get());
        }

        public IEnumerable<GenreDto> GetMusicGenres()
        {
            return Mapper.Map<IEnumerable<GenreDto>>(_unitOfWork.MusicGenreRepository.Get());
        }
    }
}
