namespace Rocket.BL.Common.DtoModels.ReleaseList
{
    public class EpisodeDto : EpisodeMinimalDto
    {
        public int TvSeriesId { get; set; }

        public string TvSeriesTitleRu { get; set; }

        public string TvSeriesTitleEn { get; set; }

        public string PosterImageUrl { get; set; }
    }
}
