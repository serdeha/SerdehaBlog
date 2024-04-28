using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Core.Extensions;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Models;
using SerdehaBlog.Core.Enums;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("/Admin/Profilim/")]
        [Route("/Admin/Profilim/Index")]
        [Route("/Admin/User/Profile/")]
        [Route("/Admin/User/Profile/Index/")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return user != null ? View(new UserUpdateViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = user.ImageUrl,
                Email = user.Email
            }) : NotFound(404);
        }

        [Route("/Admin/Profilim/")]
        [Route("/Admin/Profilim/Index")]
        [Route("/Admin/User/Profile/")]
        [Route("/Admin/User/Profile/Index/")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(UserUpdateViewModel userUpdateViewModel, IFormFile? formFile)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                user!.FirstName = userUpdateViewModel.FirstName;
                user!.LastName = userUpdateViewModel.LastName;
                user!.Email = userUpdateViewModel.Email;

                if (formFile != null && userUpdateViewModel.ImageUrl != "defaultUser.png")
                {
                    if (userUpdateViewModel.ImageUrl != null) ImageHelperExtension.DeleteImage(userUpdateViewModel.ImageUrl, "/admin/img/user");
                    user.ImageUrl = await ImageHelperExtension.UploadWebpImage(formFile, "/admin/img/user",SectionType.Author);
                }

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["IsSuccess"] = "Profiliniz başarıyla güncellendi.";
                    return Redirect("/Admin/Anasayfa/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return View(userUpdateViewModel);
                }
            }

            return View(userUpdateViewModel);
        }

        [Route("/Admin/Profilim/SifreDegistir/")]
        [Route("/Admin/User/ChangePassword/")]
        [Route("/Admin/User/ChangePassword/Index/")]
        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel userChangePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user == null) return Redirect("/Admin/Anasayfa/");

                var result = await _userManager.ChangePasswordAsync(user, userChangePasswordViewModel.CurrentPassword!, userChangePasswordViewModel.NewPassword!);

                if (result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(error.Code, error.Description);

                    return View();
                }

                await _signInManager.RefreshSignInAsync(user);
                TempData["IsSuccess"] = "Şifreniz başarıyla güncellendi.";
                return Redirect("/Admin/Anasayfa/");
            }

            return View();
        }
    }
}
