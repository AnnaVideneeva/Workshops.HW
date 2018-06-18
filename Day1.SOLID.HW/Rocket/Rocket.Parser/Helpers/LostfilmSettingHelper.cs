using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Rocket.Parser.Helpers
{
    internal static class LostfilmSettingHelper
    {
        private const string LostfilmParserSectionGroupKey = "lostfilmParser";
        private const string AlbumInfoParserSectionGroupKey = "albumInfoParser";

        private const string RunSettingsSectionKey = "runSettings";
        private const string UrlSectionKey = "url";

        private const string IsSwitchOnKey = "IsSwitchOn";
        private const string PeriodInMinutesKey = "PeriodInMinutes";
        private const string BaseUrlKey = "BaseUrl";

        public static string GetLostfilmParseIsSwitchOn()
        {
            var runSettings = (NameValueCollection)ConfigurationManager.GetSection(
                LostfilmParserSectionGroupKey + "/" + RunSettingsSectionKey);

            return runSettings.Get(IsSwitchOnKey);
        }

        public static string GetLostfilmParsePeriodInMinutes()
        {
            var runSettings = (NameValueCollection)ConfigurationManager.GetSection(
                LostfilmParserSectionGroupKey + "/" + RunSettingsSectionKey);

            return runSettings.Get(PeriodInMinutesKey);
        }

        public static string GetLostfilmParseBaseUrl()
        {
            var runSettings = (NameValueCollection)ConfigurationManager.GetSection(
                LostfilmParserSectionGroupKey + "/" + UrlSectionKey);

            return runSettings.Get(BaseUrlKey);
        }

        public static string GetAlbumInfoParseIsSwitchOn()
        {
            var runSettings = (NameValueCollection)ConfigurationManager.GetSection(
                AlbumInfoParserSectionGroupKey + "/" + RunSettingsSectionKey);

            return runSettings.Get(IsSwitchOnKey);
        }

        public static string GetAlbumInfoParsePeriodInMinutes()
        {
            var runSettings = (NameValueCollection)ConfigurationManager.GetSection(
                AlbumInfoParserSectionGroupKey + "/" + RunSettingsSectionKey);

            return runSettings.Get(PeriodInMinutesKey);
        }

        public static string GetAlbumInfoParseBaseUrl()
        {
            var runSettings = (NameValueCollection)ConfigurationManager.GetSection(
                AlbumInfoParserSectionGroupKey + "/" + UrlSectionKey);

            return runSettings.Get(BaseUrlKey);
        }
    }
}
