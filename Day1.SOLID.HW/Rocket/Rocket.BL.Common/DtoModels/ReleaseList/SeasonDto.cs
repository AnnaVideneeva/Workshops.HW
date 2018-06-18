using System.Collections.Generic;

namespace Rocket.BL.Common.DtoModels.ReleaseList
{
    public class SeasonDto
    {
        public int Number { get; set; }

        public string PosterImageUrl { get; set; }

        public IEnumerable<EpisodeMinimalDto> ListEpisode { get; set; }
    }
}