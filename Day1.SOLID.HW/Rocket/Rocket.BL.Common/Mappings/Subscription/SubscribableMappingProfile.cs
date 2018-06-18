using AutoMapper;
using Rocket.BL.Common.Models.Subscription;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.BL.Common.Mappings.Subscription
{
    public class SubscribableMappingProfile : Profile
    {
        public SubscribableMappingProfile()
        {
            CreateMap<Subscribable, SubscribableEntity>()
                .ReverseMap()
                .ForMember(dest => dest.Users, opt => opt.Ignore());
        }
    }
}
