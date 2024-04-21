using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.ContactDto;

namespace SerdehaBlog.WebUI.Areas.Admin.ViewComponents.NewMessage
{
    public class NewMessageViewComponent:ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public NewMessageViewComponent(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.MessageCount = await _contactService.GetCountAsync(x => x.IsActive && !x.IsDeleted && !x.IsRead);
            var contactList = _mapper.Map<List<NotificationContactDto>>(await _contactService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted));
            var contacts = contactList.TakeLast(5).OrderByDescending(x => x.CreatedDate).ToList();
            return View(contacts);
        }
    }
}
