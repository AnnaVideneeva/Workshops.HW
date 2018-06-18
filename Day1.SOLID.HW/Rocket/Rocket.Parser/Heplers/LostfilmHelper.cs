using System.Collections.Specialized;
using System.Configuration;

namespace Rocket.Parser.Heplers
{
    /// <summary>
    /// Хелпер для парсинга Lostfilm.
    /// </summary>
    internal static class LostfilmHelper
    {

        //настройки запуска
        private const string ParseIsSwitchOnKey = "ParseIsSwitchOn";
        private const string ParsePeriodInMinutesKey = "ParsePeriodInMinutes";

        //ссылки, начальная и частичные
        private const string ParseBaseUrlKey = "ParseBaseUrl";
        private const string AdditionalUrlToSerialListBatchKey = "AdditionalUrlToSerialListBatch";
        private const string AdditionalUrlToSerialListKey = "AdditionalUrlToSerialList";
        private const string AdditionalUrlToTvSerialEpisodesKey = "AdditionalUrlToTvSerialEpisodes";
        private const string AdditionalUrlToTvSerialPhotesKey = "AdditionalUrlToTvSerialPhotes";
        private const string AdditionalUrlToTvSerialCastsKey = "AdditionalUrlToTvSerialCasts";

        //настройки получения списка сериала
        private const string MaxRequestCountKey = "MaxRequestCount";
        private const string TakeTvSerialByRequestKey = "TakeTvSerialByRequest";
        private const string MessageNotFoundByRequestKey = "MessageNotFoundByRequest";

        //настройки для парсинга заголовка сериала из общего списка
        private const string TvSerialHeaderKeywordStatusKey = "KeywordStatus";
        private const string TvSerialHeaderKeywordYearStartKey = "KeywordYearStart";
        private const string TvSerialHeaderKeywordCanalKey = "KeywordCanal";
        private const string TvSerialHeaderKeywordGenreKey = "KeywordGenre";
        private const string TvSerailListHeaderBaseKey = "Base";
        private const string TvSerialHeaderKey = "TvSerial";
        private const string TvSerialHeaderDetailKey = "TvSerialDetail";
        private const string TvSerialHeaderLostfilmRateKey = "TvSerialLostfilmRate";
        private const string TvSerialHeaderDetailImageUrlThumbKey = "TvSerialDetailImageUrlThumb";
        private const string TvSerialHeaderDetailTvSerialNameRuKey = "TvSerialDetailTvSerialNameRu";
        private const string TvSerialHeaderDetailTvSerialNameEnKey = "TvSerialDetailTvSerialNameEn";
        private const string TvSerialHeaderDetailPaneKey = "TvSerialDetailPane";

        //настройки для парсинга сериала со страницы сериала
        private const string TvSerialOverviewKey = "TvSerialOverview";
        private const string TvSerialKeywordRateImDbKey = "TvSerialKeywordRateImDb";
        private const string TvSerialPremiereDateForParseKey = "TvSerialPremiereDateForParse";
        private const string TvSerialSummaryKey = "TvSerialSummary";
        private const string TvSerialUrlToOfficialSiteKey = "TvSerialUrlToOfficialSite";

        //настройки для парсинга серии
        private const string AllEpisodesKey = "AllEpisodes";
        private const string SeasonPostersKey = "SeasonPosters";
        private const string ClassNameBetaKey = "ClassNameBeta";
        private const string ClassNameGammaKey = "ClassNameGamma";
        private const string ClassNameDeltaKey = "ClassNameDelta";
        private const string SeasonKeywordKey = "SeasonKeyword";
        private const string EpisodeKeywordKey = "EpisodeKeyword";
        private const string GrayColor2SmallTextClassKey = "GrayColor2SmallTextClass";
        private const string SmallTextClassKey = "SmallTextClass";
        private const string RuKeywordKey = "RuKeyword";
        private const string EngKeywordKey = "EngKeyword";
        private const string DateFormatKey = "DateFormat";

        //настройки парсинга актерского и режисерского составов
        private const string ClassHeaderSimpleKey = "ClassHeaderSimple";
        private const string ClassRowKey = "ClassRow";
        private const string ClassAloadThumbKey = "ClassAloadThumb";
        private const string ClassNameRuKey = "ClassNameRu";
        private const string ClassNameEnKey = "ClassNameEn";
        private const string SelectorCastElementKey = "SelectorCastElement";
        private const string SelectorHrefCastElementKey = "SelectorHrefCastElement";
        private const string KeywordActorsKey = "KeywordActors";
        private const string KeywordDirectorsKey = "KeywordDirectors";
        private const string KeywordProducersKey = "KeywordProducers";
        private const string KeywordWritersKey = "KeywordWriters";

        //коллекции по секциям
        private static readonly NameValueCollection RunSettings;
        private static readonly NameValueCollection Urls;
        private static readonly NameValueCollection TakeSettings;
        private static readonly NameValueCollection TvSerailListHeaderSelectors;
        private static readonly NameValueCollection TvSerailSelectors;
        private static readonly NameValueCollection EpisodeSelectors;
        private static readonly NameValueCollection CastSelectors;

        /// <summary>
        /// Инициализируем все необходимые коллекции настроек для парсинга(Singlton).
        /// </summary>
        static LostfilmHelper()
        {
            RunSettings = (NameValueCollection)ConfigurationManager.GetSection(
                    ProjectNameConstants.LostfilmSectionGroupName + "/" + ProjectNameConstants.RunSettingsSectionName);

            Urls = (NameValueCollection)ConfigurationManager.GetSection(
                ProjectNameConstants.LostfilmSectionGroupName + "/" + ProjectNameConstants.UrlsSectionName);

            TakeSettings = (NameValueCollection)ConfigurationManager.GetSection(
                ProjectNameConstants.LostfilmSectionGroupName + "/" + ProjectNameConstants.TakeSettingsSectionName);

            TvSerailListHeaderSelectors = (NameValueCollection)ConfigurationManager.GetSection(
                ProjectNameConstants.LostfilmSectionGroupName + "/" + 
                ProjectNameConstants.TvSerailListHeaderSelectorsSectionName);

            TvSerailSelectors = (NameValueCollection)ConfigurationManager.GetSection(
                ProjectNameConstants.LostfilmSectionGroupName + "/" +
                ProjectNameConstants.TvSerailSelectorsSelectorsSectionName);

            EpisodeSelectors = (NameValueCollection)ConfigurationManager.GetSection(
                ProjectNameConstants.LostfilmSectionGroupName + "/" +
                ProjectNameConstants.EpisodeSelectorsSectionName);

            CastSelectors = (NameValueCollection)ConfigurationManager.GetSection(
                ProjectNameConstants.LostfilmSectionGroupName + "/" +
                ProjectNameConstants.CastSectionName);
        }

        public static string GetParseIsSwitchOn()
        {
            return RunSettings.Get(ParseIsSwitchOnKey);
        }

        public static string GetParsePeriodInMinutes()
        {
            return RunSettings.Get(ParsePeriodInMinutesKey);
        }

        public static string GetBaseUrl()
        {
            return Urls.Get(ParseBaseUrlKey);
        }

        public static string GetAdditionalUrlToSerialList()
        {
            return Urls.Get(AdditionalUrlToSerialListKey);
        }

        public static string GetAdditionalUrlToSerialBatchList()
        {
            return Urls.Get(AdditionalUrlToSerialListBatchKey);
        }

        public static string AdditionalUrlToTvSerialEpisodes()
        {
            return Urls.Get(AdditionalUrlToTvSerialEpisodesKey);
        }

        public static string AdditionalUrlToTvSerialPhotes()
        {
            return Urls.Get(AdditionalUrlToTvSerialPhotesKey);
        }

        public static string AdditionalUrlToTvSerialCasts()
        {
            return Urls.Get(AdditionalUrlToTvSerialCastsKey);
        }

        public static string GetMaxRequestCount()
        {
            return TakeSettings.Get(MaxRequestCountKey);
        }

        public static string GetTakeTvSeriasByRequest()
        {
            return TakeSettings.Get(TakeTvSerialByRequestKey);
        }

        public static string GetMessageNotFoundByRequest()
        {
            return TakeSettings.Get(MessageNotFoundByRequestKey);
        }

        public static string GetTvSerailListHeaderBase()
        {
            return TvSerailListHeaderSelectors.Get(TvSerailListHeaderBaseKey);
        }

        public static string GetTvSerialHeader()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderKey);
        }

        public static string GetTvSerialHeaderDetail()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderDetailKey);
        }

        public static string GetTvSerialHeaderLostfilmRate()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderLostfilmRateKey);
        }

        public static string GetTvSerialHeaderDetailImageUrlThumb()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderDetailImageUrlThumbKey);
        }

        public static string GetTvSerialHeaderDetailTvSerialNameRu()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderDetailTvSerialNameRuKey);
        }

        public static string GetTvSerialHeaderDetailTvSerialNameEn()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderDetailTvSerialNameEnKey);
        }

        public static string GetTvSerialHeaderDetailPane()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderDetailPaneKey);
        }

        public static string GetTvSerialHeaderKeywordStatus()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderKeywordStatusKey);
        }

        public static string GetTvSerialHeaderKeywordYearStart()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderKeywordYearStartKey);
        }

        public static string GetTvSerialHeaderKeywordCanal()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderKeywordCanalKey);
        }

        public static string GetTvSerialHeaderKeywordGenre()
        {
            return TvSerailListHeaderSelectors.Get(TvSerialHeaderKeywordGenreKey);
        }
        
        public static string GetTvSerialOverview()
        {
            return TvSerailSelectors.Get(TvSerialOverviewKey);
        }

        public static string GetTvSerialKeywordRateImDb()
        {
            return TvSerailSelectors.Get(TvSerialKeywordRateImDbKey);
        }

        public static string GetTvSerialPremiereDateForParse()
        {
            return TvSerailSelectors.Get(TvSerialPremiereDateForParseKey);
        }

        public static string GetTvSerialSummary()
        {
            return TvSerailSelectors.Get(TvSerialSummaryKey);
        }

        public static string GetTvSerialUrlToOfficialSite()
        {
            return TvSerailSelectors.Get(TvSerialUrlToOfficialSiteKey);
        }
        
        public static string GetAllEpisodes()
        {
            return EpisodeSelectors.Get(AllEpisodesKey);
        }

        public static string GetSeasonPosters()
        {
            return EpisodeSelectors.Get(SeasonPostersKey);
        }
        
        public static string GetEpisodeClassNameBeta()
        {
            return EpisodeSelectors.Get(ClassNameBetaKey);
        }

        public static string GetEpisodeClassNameGamma()
        {
            return EpisodeSelectors.Get(ClassNameGammaKey);
        }

        public static string GetEpisodeClassNameDelta()
        {
            return EpisodeSelectors.Get(ClassNameDeltaKey);
        }

        public static string GetSeasonKeyword()
        {
            return EpisodeSelectors.Get(SeasonKeywordKey);
        }

        public static string GetEpisodeKeyword()
        {
            return EpisodeSelectors.Get(EpisodeKeywordKey);
        }

        public static string GetGrayColor2SmallTextClass()
        {
            return EpisodeSelectors.Get(GrayColor2SmallTextClassKey);
        }
        
        public static string GetSmallTextClass()
        {
            return EpisodeSelectors.Get(SmallTextClassKey);
        }
        
        public static string GetRuKeyword()
        {
            return EpisodeSelectors.Get(RuKeywordKey);
        }

        public static string GetEngKeyword()
        {
            return EpisodeSelectors.Get(EngKeywordKey);
        }

        public static string GetDateFormat()
        {
            return EpisodeSelectors.Get(DateFormatKey);
        }

        public static string GetClassHeaderSimple()
        {
            return CastSelectors.Get(ClassHeaderSimpleKey);
        }

        public static string GetClassRow()
        {
            return CastSelectors.Get(ClassRowKey);
        }

        public static string GetClassAloadThumb()
        {
            return CastSelectors.Get(ClassAloadThumbKey);
        }

        public static string GetClassNameRu()
        {
            return CastSelectors.Get(ClassNameRuKey);
        }

        public static string GetClassNameEn()
        {
            return CastSelectors.Get(ClassNameEnKey);
        }

        public static string GetSelectorCastElement()
        {
            return CastSelectors.Get(SelectorCastElementKey);
        }

        public static string GetSelectorHrefCastElement()
        {
            return CastSelectors.Get(SelectorHrefCastElementKey);
        }

        public static string GetKeywordActors()
        {
            return CastSelectors.Get(KeywordActorsKey);
        }

        public static string GetKeywordDirectors()
        {
            return CastSelectors.Get(KeywordDirectorsKey);
        }

        public static string GetKeywordProducers()
        {
            return CastSelectors.Get(KeywordProducersKey);
        }

        public static string GetKeywordWriters()
        {
            return CastSelectors.Get(KeywordWritersKey);
        }
    }
}
