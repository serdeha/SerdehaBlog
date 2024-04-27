using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SerdehaBlog.Core.Enums;
using SerdehaBlog.Core.Extensions;
using SerdehaBlog.Core.Helpers.Abstract;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly WebsiteInfo _websiteInfo;
        private readonly IWritableOptions<WebsiteInfo> _websiteWritableOptions;

        public SettingsController(IOptionsSnapshot<WebsiteInfo> websiteInfo,IWritableOptions<WebsiteInfo> websiteWritableOptions)
        {
            _websiteInfo = websiteInfo.Value;
            _websiteWritableOptions = websiteWritableOptions;
        }

        [Route("/Admin/Ayarlar/")]
        [Route("/Admin/Settings/Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(_websiteInfo);
        }

        [Route("/Admin/Ayarlar/")]
        [Route("/Admin/Settings/Index")]
        [HttpPost]
        public IActionResult Index(WebsiteInfo websiteInfo, IFormFile? settingsImageFile)
        {
            _websiteWritableOptions.Update(async x =>
            {
                x.SeoKeywords = websiteInfo.SeoKeywords;
                x.SeoAuthor = websiteInfo.SeoAuthor;
                x.Title = websiteInfo.Title;
                x.SeoDescription = websiteInfo.SeoDescription;
                if(settingsImageFile is not null)
                {
                    if (!string.IsNullOrEmpty(websiteInfo.LogoPath) && websiteInfo.LogoPath is not "defaultBlogLogo.jpg") ImageHelperExtension.DeleteImage(websiteInfo.LogoPath, "/img/blog/logo/");
                    websiteInfo.LogoPath = await ImageHelperExtension.UploadWebpImage(settingsImageFile, "/img/blog/logo", SectionType.BlogLogo);
                    x.LogoPath = websiteInfo.LogoPath;
                }
            });
            TempData["IsSuccess"] = "Site ayarları başarıyla güncellendi.";
            return Redirect("/Admin/Anasayfa/");
        }
    }
}
