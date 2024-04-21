using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Business.Validations;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.ContactDto;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace SerdehaBlog.WebUI.Controllers
{
    [AllowAnonymous]
	public class ContactController : Controller
    {
        private readonly WebsiteInfo _websiteInfo;
        private readonly ContactInfo _contactInfo;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper, IOptionsSnapshot<ContactInfo> contactInfo, IOptionsSnapshot<WebsiteInfo> websiteInfo)
		{
			_contactService = contactService;
            _mapper = mapper;
            _contactInfo = contactInfo.Value;
            _websiteInfo = websiteInfo.Value;
		}

        [Route("Contact")]
        [Route("Contact/Index")]
        [Route("Iletisim")]
		public IActionResult Index()
        {
            ViewData["ContactInfo"] = _contactInfo;
            ViewData["WebsiteInfo"] = _websiteInfo;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Add(AddContactDto addContactDto)
        {
            Contact contact = _mapper.Map<Contact>(addContactDto);
            ContactValidator validator = new ContactValidator();
            ValidationResult result = await validator.ValidateAsync(contact);
            if(result.IsValid)
            {
                await _contactService.AddAsync(contact);
				return Json(new { ResultStatus = true, Data = contact }, new JsonSerializerOptions
				{
					ReferenceHandler = ReferenceHandler.Preserve
				});
			}

            string errors = string.Empty;
            foreach(var error in result.Errors)
            {
                errors += $"*{error.ErrorMessage}<br>";
            }
            return Json(new { ResultStatus = false, ErrorMessages = errors });
		}
    }
}
