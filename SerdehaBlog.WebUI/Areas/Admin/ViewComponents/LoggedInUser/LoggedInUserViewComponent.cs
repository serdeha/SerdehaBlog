using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.UserDto;

namespace SerdehaBlog.WebUI.Areas.Admin.ViewComponents.LoggedInUser
{
	public class LoggedInUserViewComponent : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public LoggedInUserViewComponent(UserManager<AppUser> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			UserDto user = _mapper.Map<UserDto>(await _userManager.GetUserAsync(HttpContext.User));
			return View(user);
		}
	}
}
