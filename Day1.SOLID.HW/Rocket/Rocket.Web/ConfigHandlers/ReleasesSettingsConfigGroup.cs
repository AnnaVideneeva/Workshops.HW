using System.Configuration;

namespace Rocket.Web.ConfigHandlers
{
    public class ReleasesSettingsConfigGroup : ConfigurationSectionGroup
    {
        public PaginationConfigSection Pagination => (PaginationConfigSection)Sections["pagination"];

        public PartialLoadConfigSection PartialLoad => (PartialLoadConfigSection)Sections["partialLoad"];
    }
}