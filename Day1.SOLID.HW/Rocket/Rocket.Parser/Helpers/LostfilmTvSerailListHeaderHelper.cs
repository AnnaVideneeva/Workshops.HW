namespace Rocket.Parser.Helpers
{
    /// <summary>
    /// Хэлпер для парсинга заголовка списков сериалов.
    /// </summary>
    public static class LostfilmTvSerailListHeaderHelper
    {
        public const string KeywordStatus = "Статус:";
        public const string KeywordYearStart = "Год выхода:";
        public const string KeywordCanal = "Канал:";
        public const string KeywordGenre = "Жанр:";

        public const string Base = "#serials_list";
        public const string TvSerial = Base + " > div:nth-child({0})";
        public const string TvSerialDetail = TvSerial + " > a";
        public const string TvSerialLostfilmRate = TvSerial + " > div.mark-green-box";
        public const string TvSerialDetailImageUrlThumb = TvSerialDetail + " > div.picture-box > img.thumb";
        private const string TvSerialDetailTvSerialDivBody = TvSerialDetail + " > div.body >";
        public const string TvSerialDetailTvSerialNameRu = TvSerialDetailTvSerialDivBody + " div.name-ru";
        public const string TvSerialDetailTvSerialNameEn = TvSerialDetailTvSerialDivBody + " div.name-en";
        public const string TvSerialDetailPane = TvSerialDetailTvSerialDivBody + " div.details-pane";

    }
}
