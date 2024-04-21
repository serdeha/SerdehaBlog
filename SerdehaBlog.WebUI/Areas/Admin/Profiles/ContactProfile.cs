using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.ContactDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ListContactDto>().ReverseMap();
            CreateMap<Contact, ContactProfile>().ReverseMap();
            CreateMap<Contact, DetailContactDto>().ReverseMap();
            CreateMap<Contact, NotificationContactDto>()
                .ForMember(dest => dest.MessageText, opt => opt.MapFrom(src => src.Text!.Substring(0,35)))
                .ReverseMap();
        }
    }
}
