using System.Linq;
using AutoMapper;
using Rocket.BL.Common.Models.Notification;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.Notification
{
    public class BillingMessageMappingProfile : Profile
    {
        public BillingMessageMappingProfile()
        {
            CreateMap<DbUser, Receiver>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.Emails, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<DbUserProfile, BillingNotification>()
                .ForMember(d => d.Receiver, opt => opt.MapFrom(s => s.DbUser))
                .ForPath(d => d.Receiver.Emails, opt => opt.MapFrom(s => s.Email.Select(x => x.Name).ToList()));
        }
    }
}