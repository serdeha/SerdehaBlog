using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.NotificationDto;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public NotificationController(INotificationService notificationService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Route("/Admin/Bildirimler/")]
        [Route("/Admin/Notification/Index/")]
        [Route("/Admin/Notification/")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetNotifications()
        {
            List<ListNotificationDto> notifications = _mapper.Map<List<ListNotificationDto>>(await _notificationService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted));

            if (notifications.Any())
            {
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = notifications }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> Confirm(int notificationId)
        {
            var notification = await _notificationService.GetWithFilterAsync(x=>x.IsActive && !x.IsDeleted && x.Id == notificationId);

            if(notification != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                notification.ModifiedDate = DateTime.Now;
                notification.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                notification.IsRead = true;
                await _notificationService.UpdateAsync(notification);
                ConfirmNotificationDto notificationDto = _mapper.Map<ConfirmNotificationDto>(notification);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = notificationDto }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> UnConfirm(int notificationId)
        {
            var notification = await _notificationService.GetWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.Id == notificationId);

            if(notification != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                notification.ModifiedDate = DateTime.Now;
                notification.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                notification.IsRead = false;
                await _notificationService.UpdateAsync(notification);
                UnconfirmNotificationDto notificationDto = _mapper.Map<UnconfirmNotificationDto>(notification);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = notificationDto }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public IActionResult RefreshNavigationBar()
        {
            return PartialView("_NavbarPartialView");
        }
    }
}
