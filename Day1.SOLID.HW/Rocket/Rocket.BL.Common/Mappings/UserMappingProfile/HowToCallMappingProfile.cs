using AutoMapper;
using Rocket.BL.Common.Models.User;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.BL.Common.Mappings.UserMappingProfile
{
    /// <summary>
    /// Профиль сопоставления доменной модели сведений о том, как обращаться к пользователю, с моделью хранения сведений о том, как обращаться к пользователю.
    /// </summary>
    public class HowToCallMappingProfile : Profile
    {
        public HowToCallMappingProfile()
        {
            CreateMap<HowToCall, DbHowToCall>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}