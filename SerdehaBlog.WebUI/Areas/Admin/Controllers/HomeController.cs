using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.CategoryDto;
using System.Text.Json.Serialization;
using System.Text.Json;
using AspNetCore.SEOHelper.Sitemap;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Extensions;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IMapper _mapper;
        private readonly string _url, _rootPath;

        public HomeController(ICategoryService categoryService, IArticleService articleService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _articleService = articleService;
			_mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _url = "https://www.serdeha.com";
            _rootPath = _webHostEnvironment.ContentRootPath;
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

        public async Task<JsonResult> CreateSiteMap()
        {
            List<SitemapNode> siteMapList = new List<SitemapNode>();
            List<Article> articles = await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted);

            siteMapList.Add(new SitemapNode
            {
                LastModified = DateTime.Now,
                Frequency = SitemapFrequency.Daily,
                Priority = 1.0,
                Url = $"{_url}/"
            });

            if (articles.Any())
            {
                foreach (var article in articles)
                {
                    siteMapList.Add(new SitemapNode
                    {
                        LastModified = article.ModifiedDate,
                        Frequency = SitemapFrequency.Weekly,
                        Priority = 0.5,
                        Url = $"{_url}/{Url.FriendlyUrlHelper(article.Title!)}/{article.Id}"
                    });
                }
            }

            if (System.IO.File.Exists($"{_rootPath}/sitemap.xml"))
                System.IO.File.Delete($"{_rootPath}/sitemap.xml");

            new SitemapDocument().CreateSitemapXML(siteMapList, _rootPath);

            if(new SitemapDocument().LoadFromFile(_rootPath).Count > 0)
                return Json(JsonSerializer.Serialize(new { ResultStatus = true }), new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                });


            return Json(JsonSerializer.Serialize(new { ResultStatus = false }), new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
        }
    }
}
