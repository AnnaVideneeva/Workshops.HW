using System.Linq;
using AutoMapper;
using Rocket.BL.Common.Models.Notification;
using Rocket.BL.Common.Models.ReleaseList;
using Rocket.BL.Common.Models.Subscription;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.DbModels.Subscription;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.Notification
{
    public class MusicNotificationMappingProfile : Profile
    {
        public MusicNotificationMappingProfile()
        {
            CreateMap<DbUser, Receiver>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForPath(
                    d => d.Emails,
                    opt => opt.MapFrom(s => s.DbUserProfile.Email.Select(x => x.Name)
                        .ToList()));

            CreateMap<Musician, DbMusician>()
                .IncludeBase<Subscribable, SubscribableEntity>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ReverseMap();

            CreateMap<DbMusic, MusicNotification>()
                .ForMember(d => d.Receivers, opt => opt.MapFrom(s => s.Users))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.ReleaseDate, opt => opt.MapFrom(s => s.ReleaseDate))
                .ForMember(d => d.Musicians, opt => opt.MapFrom(s => s.Musicians.ToList()));
        }
    }
}
