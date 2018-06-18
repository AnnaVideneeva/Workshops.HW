using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.NLog;

namespace Rocket.Web
{
    public class LoggerConfig
    {
        public static void Configure()
        {
            var prop = new NameValueCollection
            {
                { "configType", "FILE" },
                { "configFile", "~/NLog.config" }
            };
            LogManager.Adapter = new NLogLoggerFactoryAdapter(prop);
        }
    }
}