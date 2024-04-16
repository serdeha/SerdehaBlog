using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.AboutDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Profiles
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, UpdateAboutDto>().ReverseMap();
        }
    }
}
