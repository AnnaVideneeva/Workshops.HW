using AutoMapper;
using Rocket.BL.Common.Models.User;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.UserMappingProfile
{
    /// <summary>
    /// Профиль сопоставления доменной модели пользователя с моделью хранения данных пользователя.
    /// </summary>
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, DbUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.AccountStatus, opt => opt.MapFrom(src => src.AccountStatus))
                .ForMember(dest => dest.AccountLevel, opt => opt.MapFrom(src => src.AccountLevel))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles))
                .ReverseMap();
        }
    }
}