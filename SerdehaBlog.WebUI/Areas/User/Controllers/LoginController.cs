using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.User.Models;

namespace SerdehaBlog.WebUI.Areas.User.Controllers
{
    [Area("User")]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
		{
			_signInManager = signInManager;
		}

        [Route("/User/Login/Index")]
        [Route("/User/Login/")]
        [Route("/Kullanici/Giris/")]
        [Route("/Kullanici/Giris/Index/")]
        [AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			if (User.Identity!.IsAuthenticated)
			{
				TempData["IsNotSuccess"] = "Sisteme zaten giriş yaptınız.";
				return Redirect("/Admin/Anasayfa/");
			}
			return View();
		}

        [Route("/User/Login/Index")]
        [Route("/User/Login/")]
        [Route("/Kullanici/Giris/")]
        [Route("/Kullanici/Giris/Index/")]
        [AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel loginViewModel, string? returnUrl = null)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username!, loginViewModel.Password!, loginViewModel.RememberMe, false);
				if (result.Succeeded)
				{
					return RedirectToLocal(returnUrl!);
				}
				else
				{
					ModelState.AddModelError("", "Giriş başarısız. Lütfen tekrar deneyin.");
				}
			}
			return View(loginViewModel);
		}

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return Redirect("/Admin/Anasayfa/");
			}
		}

        [Route("/User/Login/Logout/{returnUrl?}")]
        [Route("/Kullanici/Cikis/{returnUrl?}")]
        public async Task<IActionResult> Logout(string? returnUrl = null)
		{
			await _signInManager.SignOutAsync();
			return RedirectToLocal(returnUrl!);
		}
	}
}
