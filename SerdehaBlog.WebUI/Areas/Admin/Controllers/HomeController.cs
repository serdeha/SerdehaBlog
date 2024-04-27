using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	public class HomeController : Controller
	{
        [Route("/Admin/Anasayfa/")]
        [Route("/Admin/Home/")]
        [Route("/Admin/Home/Index/")]
        public IActionResult Index()
		{
			return View();
		}
    }
}
