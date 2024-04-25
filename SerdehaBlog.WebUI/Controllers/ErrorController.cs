using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SerdehaBlog.WebUI.Controllers
{
    [Route("Error/{statusCode}")]
    [AllowAnonymous]
    public class ErrorController:Controller
    {
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.StatusCode = statusCodeResult!.OriginalStatusCode;
                    ViewBag.ErrorMessage = "Üzgünüm, aradığınız sayfa bulunamadı.";                    
                    break;
                case 500:
                    ViewBag.StatusCode = statusCodeResult!.OriginalStatusCode;
                    ViewBag.ErrorMessage = "Sunucu bağlantısı kurulurken bir hata oluştu.";
                    break;
                case 400:
                    ViewBag.StatusCode = statusCodeResult!.OriginalStatusCode;
                    ViewBag.ErrorMessage = "Erişim engellendi. Eksik ya da hatalı parametre gönderildi.";
                    break;
                case 403:
                    ViewBag.StatusCode = statusCodeResult!.OriginalStatusCode;
                    ViewBag.ErrorMessage = "Görünüşe göre izniniz olmayan bir alana girmeye çalışıyorsunuz.";
                    break;
            }

            return View();
        }
    }
}
