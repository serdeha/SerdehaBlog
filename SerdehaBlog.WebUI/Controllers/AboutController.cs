using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.WebUI.Dtos.AboutDto;

namespace SerdehaBlog.WebUI.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [Route("About")]
        [Route("About/Index")]
        [Route("Hakkimda")]
        public async Task<IActionResult> Index()
        {
            AboutDto about = _mapper.Map<AboutDto>(await _aboutService.GetWithFilterAsync(x => x.IsActive && !x.IsDeleted));
            return View(about);
        }
    }
}
