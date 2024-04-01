using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.AboutDto;

namespace SerdehaBlog.WebUI.Profiles
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About,AboutDto>().ReverseMap();
        }
    }
}
