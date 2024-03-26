using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.SocialMediaDto;

namespace SerdehaBlog.WebUI.Profiles
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, ListSocialMediaDto>().ReverseMap();
        }
    }
}
