using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Core.Helpers.Abstract;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.ContactDto;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly ContactInfo _contactInfo;
        private readonly IWritableOptions<ContactInfo> _contactInfoWritableOptions;
        private readonly UserManager<AppUser> _userManager;

        public ContactController(IContactService contactService, IMapper mapper, IOptionsSnapshot<ContactInfo> contactInfo, IWritableOptions<ContactInfo> contactInfoWritableOptions, UserManager<AppUser> userManager)
        {
            _contactService = contactService;
            _mapper = mapper;
            _contactInfo = contactInfo.Value;
            _contactInfoWritableOptions = contactInfoWritableOptions;
            _userManager = userManager;
        }

        [Route("/Admin/Iletisim/")]
        [Route("/Admin/Contact/Index/")]
        [Route("/Admin/Contact/")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Delete(int contactId)
        {
            var contact = _contactService.GetById(contactId);

            if (contact != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                contact.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                contact.ModifiedDate = DateTime.Now;
                await _contactService.UpdateAsync(contact);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = contact }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        [Route("/Admin/Iletisim/Detay/{contactId?}")]
        [Route("/Admin/Contact/Detail/{contactId?}")]
        [HttpGet]
        public async Task<IActionResult> Detail(int contactId)
        {
            DetailContactDto contactDto = _mapper.Map<DetailContactDto>(await _contactService.GetByIdAsync(contactId));
            return contactDto != null ? View(contactDto) : NotFound(404);
        }

        [Route("/Admin/Iletisim/Ayarlar/")]
        [Route("/Admin/Contact/Settings/")]
        [HttpGet]
        public IActionResult Settings()
        {
            return View(_contactInfo);
        }

        [Route("/Admin/Iletisim/Ayarlar/")]
        [Route("/Admin/Contact/Settings/")]
        [HttpPost]
        public IActionResult Settings(ContactInfo contactInfo)
        {
            _contactInfoWritableOptions.Update(x =>
            {
                x.Location = contactInfo.Location;
                x.LocationValue = contactInfo.LocationValue;
                x.Title = contactInfo.Title;
                x.Subtitle = contactInfo.Subtitle;
                x.Email = contactInfo.Email;
                x.EmailValue = contactInfo.EmailValue;
                x.Phone = contactInfo.Phone;
                x.PhoneValue = contactInfo.PhoneValue;
            });
            TempData["IsSuccess"] = "İletişim başarıyla güncellendi.";
            return Redirect("/Admin/Anasayfa/");
        }

        public async Task<JsonResult> GetContacts()
        {
            var contactModels = await _contactService.GetAllWithFilterAsync(x => !x.IsDeleted);
            var contacts = _mapper.Map<List<ListContactDto>>(contactModels);

            if (contacts.Any())
            {
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = contacts }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> Read(int contactId)
        {
            var contact = _contactService.GetById(contactId);
            if(contact != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                contact.IsRead = true;
                contact.ModifiedDate = DateTime.Now;
                contact.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                await _contactService.UpdateAsync(contact);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = contact }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }
    }
}
