using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.ContactDto;

namespace SerdehaBlog.WebUI.Profiles
{
	public class ContactProfile : Profile
	{
        public ContactProfile()
        {
            CreateMap<Contact, AddContactDto>().ReverseMap();
        }
    }
}
