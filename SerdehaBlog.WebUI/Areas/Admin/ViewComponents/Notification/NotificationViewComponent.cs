using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.NotificationDto;

namespace SerdehaBlog.WebUI.Areas.Admin.ViewComponents.Notification
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationViewComponent(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.NotificationCount = await _notificationService.GetCountAsync(x => x.IsActive && !x.IsDeleted && !x.IsRead);
            List<ListNotificationDto> notificationList = _mapper.Map<List<ListNotificationDto>>(await _notificationService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted));
            var notifications = notificationList.TakeLast(5).OrderByDescending(x => x.CreatedDate).ToList();
            return View(notifications);
        }
    }
}
