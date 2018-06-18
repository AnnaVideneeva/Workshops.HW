using System;

namespace Rocket.BL.Common.DtoModels.ReleaseList
{
    public class EpisodeMinimalDto
    {
        public int Id { get; set; }

        public string TitleRu { get; set; }

        public string TitleEn { get; set; }

        public DateTime? ReleaseDateRu { get; set; }

        public DateTime? ReleaseDateEn { get; set; }

        public int SeasonNumber { get; set; }

        public int Number { get; set; }

        public string UrlForEpisodeSource { get; set; }
    }
}