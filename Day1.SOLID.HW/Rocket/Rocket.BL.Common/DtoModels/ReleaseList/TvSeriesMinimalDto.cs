using System.Collections.Generic;

namespace Rocket.BL.Common.DtoModels.ReleaseList
{
    public class TvSeriesMinimalDto
    {
        public int Id { get; set; }
        
        public string TitleRu { get; set; }
        
        public string TitleEn { get; set; }
        
        public string PosterImageUrl { get; set; }
        
        public double LostfilmRate { get; set; }
        
        public string CurrentStatus { get; set; }
        
        public string TvSerialCanal { get; set; }
        
        public string TvSerialYearStart { get; set; }
        
        public IEnumerable<GenreDto> Genres { get; set; }

        public bool IsUserSubscribed { get; set; }
    }
}
