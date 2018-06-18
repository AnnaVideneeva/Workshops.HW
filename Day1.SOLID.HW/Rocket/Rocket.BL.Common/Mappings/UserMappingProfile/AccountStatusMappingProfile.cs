using AutoMapper;
using Rocket.BL.Common.Models.User;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.UserMappingProfile
{
    /// <summary>
    /// Профиль сопоставления доменной модели статуса аккаунта пользователя с моделью хранения статуса аккаунта пользователя.
    /// </summary>
    public class AccountStatusMappingProfile : Profile
    {
        public AccountStatusMappingProfile()
        {
            CreateMap<AccountStatus, DbAccountStatus>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}