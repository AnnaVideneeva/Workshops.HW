using AutoMapper;
using Rocket.BL.Common.Models.User;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.UserMappingProfile
{
    /// <summary>
    /// Профиль сопоставления доменной модели адреса электронной почты дополнительной информации пользователю с моделью адреса электронной почты дополнительной информации пользователю.
    /// </summary>
    public class EmailAddressMappingProfile : Profile
    {
        public EmailAddressMappingProfile()
        {
            CreateMap<EmailAddress, DbEmailAddress>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();
        }
    }
}