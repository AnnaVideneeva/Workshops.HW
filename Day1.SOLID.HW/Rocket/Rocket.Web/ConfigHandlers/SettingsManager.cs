using System.Web.Configuration;

namespace Rocket.Web.ConfigHandlers
{
    public static class SettingsManager
    {
        public static ReleasesSettingsConfigGroup ReleasesSettings =>
            (ReleasesSettingsConfigGroup)WebConfigurationManager.OpenWebConfiguration("/")
                .GetSectionGroup("releasesSettings");
    }
}