using System.Collections.Generic;

namespace Rocket.BL.Common.DtoModels.ReleaseList
{
    public class TvSeriesPersonsDto : TvSeriesDetailsDto
    {
        public IEnumerable<PersonMinimalDto> Persons { get; set; }
    }
}