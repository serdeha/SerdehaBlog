using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.UserDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Profiles
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => string.Concat(src.FirstName," ",src.LastName)))
                .ReverseMap();
        }
    }
}
