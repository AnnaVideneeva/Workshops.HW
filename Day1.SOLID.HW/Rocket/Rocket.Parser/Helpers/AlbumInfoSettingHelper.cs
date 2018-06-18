using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.Parser.Helpers
{
    public static class AlbumInfoSettingHelper
    {
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
