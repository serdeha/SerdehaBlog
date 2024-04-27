using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Business.Validations;
using SerdehaBlog.Core.Extensions;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.ArticleDto;
using SerdehaBlog.Core.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _mapper = mapper;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        [Route("/Admin/Makaleler/")]
        [Route("/Admin/Article/Index/")]
        [Route("/Admin/Article/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Admin/Makale/Ekle/")]
        [Route("/Admin/Article/Add/")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await GetCategories();
            return View();
        }

        [Route("/Admin/Makale/Ekle/")]
        [Route("/Admin/Article/Add/")]
        [HttpPost]
        public async Task<IActionResult> Add(AddArticleDto addArticleDto, IFormFile? articleImageFile)
        {
            Article article = _mapper.Map<Article>(addArticleDto);
            ArticleValidator validator = new ArticleValidator();
            ValidationResult result = await validator.ValidateAsync(article);
            if (result.IsValid)
            {
                article.ThumbnailPath = articleImageFile != null ? await ImageHelperExtension.UploadWebpImage(articleImageFile, "/admin/img/blog/", SectionType.Blog) : "defaultArticle.png";
                await _articleService.AddAsync(article);
                return Redirect("/Admin/Makaleler/");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                ViewBag.Categories = await GetCategories();
                return View(addArticleDto);
            }
        }

        [Route("/Admin/Makale/Guncelle/{makaleId?}")]
        [Route("/Admin/Article/Update/{makaleId?}")]
        [HttpGet]
        public async Task<IActionResult> Update(int articleId)
        {
            ViewBag.Categories = await GetCategories();
            UpdateArticleDto articleDto = _mapper.Map<UpdateArticleDto>(await _articleService.GetByIdAsync(articleId));
            return articleDto != null ? View(articleDto) : NotFound(404);
        }

        [Route("/Admin/Makale/Guncelle/")]
        [Route("/Admin/Article/Update/")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateArticleDto articleDto, IFormFile? articleImageFile)
        {
            Article article = _mapper.Map<Article>(articleDto);
            ArticleValidator validator = new ArticleValidator();
            ValidationResult result = await validator.ValidateAsync(article);
            if (result.IsValid)
            {
                if (articleImageFile is not null)
                {
                    if (!string.IsNullOrEmpty(article.ThumbnailPath) && article.ThumbnailPath is not "defaultThumbnail.jpg") ImageHelperExtension.DeleteImage(article.ThumbnailPath, "/admin/img/blog/");
                    article.ThumbnailPath = await ImageHelperExtension.UploadWebpImage(articleImageFile, "/admin/img/blog/", SectionType.Blog);
                }
                var user = await _userManager.GetUserAsync(HttpContext.User);
                article.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                article.ModifiedDate = DateTime.Now;
                await _articleService.UpdateAsync(article);
                TempData["IsSuccess"] = $"{article.Title} başarıyla güncellendi.";
                return Redirect("/Admin/Makaleler/");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }
            ViewBag.Categories = await GetCategories();
            return View(articleDto);
        }

        public async Task<JsonResult> Delete(int articleId)
        {
            var article = _articleService.GetById(articleId);
            if (article != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                article.ModifiedDate = DateTime.Now;
                article.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                await _articleService.DeleteAsync(article);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = article }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> GetAllArticles()
        {
            var articles = _mapper.Map<List<ListArticleDto>>(await _articleService.GetAllWithFilterAsync(x => !x.IsDeleted, x => x.Category!));

            if (articles.Any())
            {
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = articles }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<SelectList> GetCategories()
        {
            return new SelectList(await _categoryService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted), "Id", "Name");
        }

        [HttpPost]
        public async Task<JsonResult> UploadPostImage(IFormFile formFile)
        {
            string imagePath = Path.Combine("/admin/img/blog/inPostImage", await ImageHelperExtension.UploadWebpImage(formFile, "/admin/img/blog/inPostImage/", SectionType.Default));
            return Json(new { url = imagePath });
        }
    }
}
