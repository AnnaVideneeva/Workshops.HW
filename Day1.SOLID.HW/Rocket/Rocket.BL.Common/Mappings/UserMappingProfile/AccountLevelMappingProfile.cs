using AutoMapper;
using Rocket.BL.Common.Models.User;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.UserMappingProfile
{
    /// <summary>
    /// Профиль сопоставления доменной модели уровня аккаунта пользователя с моделью хранения уровня аккаунта пользователя.
    /// </summary>
    public class AccountLevelMappingProfile : Profile
    {
        public AccountLevelMappingProfile()
        {
            CreateMap<AccountLevel, DbAccountLevel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}