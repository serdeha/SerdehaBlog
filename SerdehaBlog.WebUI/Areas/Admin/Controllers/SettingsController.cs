using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View(_websiteInfo);
        }

        [HttpPost]
        public IActionResult Index(WebsiteInfo websiteInfo)
        {
            _websiteWritableOptions.Update(x =>
            {
                x.SeoKeywords = websiteInfo.SeoKeywords;
                x.SeoAuthor = websiteInfo.SeoAuthor;
                x.Title = websiteInfo.Title;
                x.SeoDescription = websiteInfo.SeoDescription;
            });
            TempData["IsSuccess"] = "Site ayarları başarıyla güncellendi.";
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
