using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SerdehaBlog.Core.Enums;
using SerdehaBlog.Core.Extensions;
using SerdehaBlog.Core.Helpers.Abstract;
using SerdehaBlog.Core.TagHelpers;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly WebsiteInfo _websiteInfo;
        private readonly IWritableOptions<WebsiteInfo> _websiteWritableOptions;
        private readonly GoogleAnalyticsOptions _googleAnalyticsOptions;
        private readonly IWritableOptions<GoogleAnalyticsOptions> _googleAnalyticsWritableOptions;
        private readonly GoogleAdsenseOptions _googleAdsenseOptions;
        private readonly IWritableOptions<GoogleAdsenseOptions> _googleAdsenseWritableOptions;

        public SettingsController(IOptionsSnapshot<WebsiteInfo> websiteInfo,IWritableOptions<WebsiteInfo> websiteWritableOptions,
            IOptionsSnapshot<GoogleAnalyticsOptions> googleAnalyticsOptions, IWritableOptions<GoogleAnalyticsOptions> googleAnalyticsWritableOptions,
            IOptionsSnapshot<GoogleAdsenseOptions> googleAdsenseOptions,IWritableOptions<GoogleAdsenseOptions> googleAdsenseWritableOptions)
        {
            _websiteInfo = websiteInfo.Value;
            _websiteWritableOptions = websiteWritableOptions;
            _googleAnalyticsOptions = googleAnalyticsOptions.Value;
            _googleAnalyticsWritableOptions = googleAnalyticsWritableOptions;
            _googleAdsenseOptions = googleAdsenseOptions.Value;
            _googleAdsenseWritableOptions = googleAdsenseWritableOptions;
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
        public IActionResult Index(WebsiteInfo websiteInfo, IFormFile? settingsImageFile, IFormFile? faviconImageFile)
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
                if(faviconImageFile is not null)
                {
                    if (!string.IsNullOrEmpty(websiteInfo.FaviconPath) && websiteInfo.FaviconPath is not "defaultBlogFavicon.jpg") ImageHelperExtension.DeleteImage(websiteInfo.FaviconPath, "/img/blog/favicon/");
                    websiteInfo.FaviconPath = ImageHelperExtension.UploadImage(faviconImageFile, "/img/blog/favicon");
                    x.FaviconPath = websiteInfo.FaviconPath;
                }
            });
            TempData["IsSuccess"] = "Site ayarları başarıyla güncellendi.";
            return Redirect("/Admin/Anasayfa/");
        }

        [Route("/Admin/Ayarlar/Analytics")]
        [Route("/Admin/Settings/Analytics")]
        [HttpGet]
        public IActionResult Analytics()
        {
            return View(_googleAnalyticsOptions);
        }

        [Route("/Admin/Ayarlar/Analytics")]
        [Route("/Admin/Settings/Analytics")]
        [HttpPost]
        public IActionResult Analytics(GoogleAnalyticsOptions googleAnalyticsOptions)
        {
            _googleAnalyticsWritableOptions.Update(x =>
            {
                x.TrackingCode = googleAnalyticsOptions.TrackingCode;
            });
            TempData["IsSuccess"] = "Google Analytics ayarları başarıyla güncellendi.";
            return Redirect("/Admin/Anasayfa");
        }

        [Route("/Admin/Ayarlar/Adsense")]
        [Route("/Admin/Settings/Adsense")]
        [HttpGet]
        public IActionResult Adsense()
        {
            return View(_googleAdsenseOptions);
        }

        [Route("/Admin/Ayarlar/Adsense")]
        [Route("/Admin/Settings/Adsense")]
        [HttpPost]
        public IActionResult Adsense(GoogleAdsenseOptions googleAdsenseOptions)
        {
            _googleAdsenseWritableOptions.Update(x =>
            {
                x.TrackingCode = googleAdsenseOptions.TrackingCode;
            });
            TempData["IsSuccess"] = "Google Adsense ayarları başarıyla güncellendi.";
            return Redirect("/Admin/Anasayfa");
        }
    }
}
