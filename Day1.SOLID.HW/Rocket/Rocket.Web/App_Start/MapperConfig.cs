using AutoMapper;

namespace Rocket.Web
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => { cfg.AddProfiles("Rocket.BL.Common"); });
        }
    }
}