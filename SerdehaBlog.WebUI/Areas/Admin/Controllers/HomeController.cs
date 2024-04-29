using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.CategoryDto;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

        public HomeController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
			_mapper = mapper;
        }

        [Route("/Admin/Anasayfa/")]
        [Route("/Admin/Home/")]
        [Route("/Admin/Home/Index/")]
        public IActionResult Index()
		{
			return View();
		}

		public async Task<JsonResult> GetChartData()
		{
			List<BlogChartDto> blogCharts = _mapper.Map<List<BlogChartDto>>(await _categoryService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted, x => x.Articles!));

            if (blogCharts.Any())
			{
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = blogCharts }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }
    }
}
