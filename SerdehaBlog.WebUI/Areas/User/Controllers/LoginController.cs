using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Validations;
using SerdehaBlog.Core.Extensions;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.UserDto;
using SerdehaBlog.WebUI.Areas.User.Models;

namespace SerdehaBlog.WebUI.Areas.User.Controllers
{
	[Area("User")]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IMapper _mapper;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_mapper = mapper;
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			if (User.Identity!.IsAuthenticated)
			{
				TempData["IsNotSuccess"] = "Sisteme zaten giriş yaptınız.";
				return RedirectToAction("Index", "Home", new { area = "Admin" });
			}
			return View();
		}

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
				return RedirectToAction("Index", "Home", new { area = "Admin" });
			}
		}

		public async Task<IActionResult> Logout(string? returnUrl = null)
		{
			await _signInManager.SignOutAsync();
			return RedirectToLocal(returnUrl!);
		}
	}
}
