using System.Linq;
using AutoMapper;
using Rocket.BL.Common.Models.Notification;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.Notification
{
    public class EpisodeNotificationMappingProfile : Profile
    {
        public EpisodeNotificationMappingProfile()
        {
            CreateMap<DbUser, Receiver>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(
                    d => d.Emails,
                    opt => opt.MapFrom(s => s.DbUserProfile.Email.Select(x => x.Name)
                        .ToList()));

            CreateMap<EpisodeEntity, EpisodeNotification>()
                .ForMember(d => d.Receivers, opt => opt.MapFrom(s => s.Users))
                .ForPath(d => d.Title, opt => opt.MapFrom(s => s.Season.TvSeries.TitleRu))
                .ForPath(d => d.SeasonNumber, opt => opt.MapFrom(s => s.Season.Number))
                .ForMember(d => d.EpisodeNumber, opt => opt.MapFrom(s => s.Number))
                .ForMember(d => d.ReleaseDate, opt => opt.MapFrom(s => s.ReleaseDateRu));
        }
    }
}