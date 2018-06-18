using AutoMapper;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.DAL.Common.DbModels.DbPersonalArea;

namespace Rocket.BL.Common.Mappings.PersonalAreaMappings
{
    /// <summary>
    /// Настройка маппинга между доменной моделью UserProfile и моделью хранения DbUserProfile.
    /// </summary>
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserProfile, DbUserProfile>()
                .ForMember(dbu => dbu.DbUser_Id, u => u.MapFrom(src => src.Id))
                .ForPath(dbu => dbu.DbUser.FirstName, u => u.MapFrom(src => src.FirstName))
                .ForPath(dbu => dbu.DbUser.LastName, u => u.MapFrom(src => src.LastName))
                .ForMember(dbu => dbu.Avatar, u => u.MapFrom(src => src.Avatar))
                .ForMember(dbu => dbu.Email, u => u.MapFrom(src => src.Emails))
                .ForMember(dbu => dbu.Genres, u => u.MapFrom(src => src.Genres))
                .ForMember(dbu => dbu.MusicGenres, u => u.MapFrom(src => src.MusicGenre))
                .ReverseMap();
        }
    }
}