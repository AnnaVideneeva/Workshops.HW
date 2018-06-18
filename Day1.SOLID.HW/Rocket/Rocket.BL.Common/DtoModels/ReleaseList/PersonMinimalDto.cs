namespace Rocket.BL.Common.DtoModels.ReleaseList
{
    public class PersonMinimalDto
    {
        public int Id { get; set; }

        public string FullNameRu { get; set; }

        public string FullNameEn { get; set; }

        public string PhotoThumbnailUrl { get; set; }

        public string PersonType { get; set; }
    }
}