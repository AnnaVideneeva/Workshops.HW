using System.Configuration;

namespace Rocket.Web.ConfigHandlers
{
    public class PartialLoadConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("topPersonsCount", DefaultValue = 4)]
        public int TopPersonsCount
        {
            get => (int)this["topPersonsCount"];
            set => this["topPersonsCount"] = value;
        }

        [ConfigurationProperty("lastEpisodesCount", DefaultValue = 5)]
        public int LastEpisodesCount
        {
            get => (int)this["lastEpisodesCount"];
            set => this["lastEpisodesCount"] = value;
        }
    }
}