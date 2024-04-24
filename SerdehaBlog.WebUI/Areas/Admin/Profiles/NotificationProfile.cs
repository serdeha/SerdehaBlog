using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.NotificationDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, ListNotificationDto>().ReverseMap();
        }
    }
}
