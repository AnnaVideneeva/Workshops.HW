using System.Collections.Generic;

namespace Rocket.BL.Common.DtoModels.ReleaseList
{
    public class TvSeriesFullDto : TvSeriesMinimalDto
    {
        public double RateImDb { get; set; }

        public string UrlToOfficialSite { get; set; }

        public IEnumerable<SeasonDto> Seasons { get; set; }

        public IEnumerable<PersonMinimalDto> Persons { get; set; }

        public string Summary { get; set; }
    }
}
