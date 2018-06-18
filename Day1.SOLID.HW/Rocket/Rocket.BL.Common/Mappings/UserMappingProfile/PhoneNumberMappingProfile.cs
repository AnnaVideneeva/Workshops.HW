using AutoMapper;
using Rocket.BL.Common.Models.User;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.UserMappingProfile
{
    /// <summary>
    /// Профиль сопоставления доменной модели телефонного номера дополнительной информации пользователя с моделью хранения телефонного нмоера дополнительной информации пользователю.
    /// </summary>
    public class PhoneNumberMappingProfile : Profile
    {
        public PhoneNumberMappingProfile()
        {
            CreateMap<PhoneNumber, DbPhoneNumber>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ReverseMap();
        }
    }
}