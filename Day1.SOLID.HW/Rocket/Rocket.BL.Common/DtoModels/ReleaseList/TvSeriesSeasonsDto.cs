using System.Collections.Generic;

namespace Rocket.BL.Common.DtoModels.ReleaseList
{
    public class TvSeriesSeasonsDto : TvSeriesDetailsDto
    {
        public IEnumerable<SeasonDto> Seasons { get; set; }
    }
}