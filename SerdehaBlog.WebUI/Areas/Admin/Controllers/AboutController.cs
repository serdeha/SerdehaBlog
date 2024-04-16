using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Business.Validations;
using SerdehaBlog.Core.Enums;
using SerdehaBlog.Core.Extensions;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.AboutDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AboutController(IAboutService aboutService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UpdateAboutDto updateAboutDto = _mapper.Map<UpdateAboutDto>(await _aboutService.GetAbout());
            return updateAboutDto != null ? View(updateAboutDto) : NotFound(404);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateAboutDto updateAboutDto, IFormFile aboutImageFile)
        {
            About about = _mapper.Map<About>(updateAboutDto);
            AboutValidator validator = new AboutValidator();
            ValidationResult result = await validator.ValidateAsync(about);
            if (result.IsValid)
            {
                if (aboutImageFile is not null)
                {
                    if (!string.IsNullOrEmpty(about.ImagePath) && about.ImagePath is not "defaultAbout.jpg") ImageHelperExtension.DeleteImage(about.ImagePath, "/img/about/");
                    about.ImagePath = await ImageHelperExtension.UploadWebpImage(aboutImageFile, "/img/about/", SectionType.Default);
                }

                var user = await _userManager.GetUserAsync(HttpContext.User);
                about.ModifiedDate = DateTime.Now;
                about.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                await _aboutService.UpdateAsync(about);
                TempData["IsSuccess"] = $"Hakkımda sayfası başarıyla güncellendi.";
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }
            return View(updateAboutDto);
        }
    }
}
