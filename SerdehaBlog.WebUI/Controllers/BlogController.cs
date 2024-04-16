using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.ArticleDto;
using X.PagedList;

namespace SerdehaBlog.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public BlogController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        //pasife alınan kategoriler anasayfada görünmesin.
        public async Task<IActionResult> Index(int? kategori, int sayfa = 1)
        {
            ViewBag.CategoryId = kategori.HasValue ? kategori.Value.ToString() : "";
            List<Article> articles = kategori.HasValue ?
                await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.CategoryId == kategori.Value, x => x.Category!, x => x.AppUser!) :
                await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted, x => x.Category!, x => x.AppUser!);

            articles = articles.Where(x => x.IsActive).ToList();

            List<ListArticleDto> articleResults = _mapper.Map<List<ListArticleDto>>(articles);

            return View(await articleResults.OrderByDescending(x => x.Date).ToPagedListAsync(sayfa, 3));
        }

        [Route("Blog/Ara/{kelime?}")]
        public async Task<IActionResult> Search(string kelime, int sayfa = 1)
        {
            ViewBag.Kelime = string.IsNullOrEmpty(kelime) ? "" : kelime;
            List<Article> searchedArticles = string.IsNullOrEmpty(kelime) ?
                await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted, x => x.Category!, x => x.AppUser!) :
                await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted && (x.Content!.Contains(kelime) || x.CreatedByName!.Contains(kelime) || x.SeoTags!.Contains(kelime)), x => x.Category!, x => x.AppUser!);

            List<ListArticleDto> articleResults = _mapper.Map<List<ListArticleDto>>(searchedArticles);

            return View(await articleResults.OrderByDescending(x => x.Date).ToPagedListAsync(sayfa, 3));
        }

        public async Task<IActionResult> ReadMore(int articleId)
        {
            var article = _mapper.Map<DetailArticleDto>(await _articleService.GetWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.Id == articleId, x => x.Category!, x => x.AppUser!));

            if (article != null)
            {
                ViewBag.ArticleId = articleId;
                ViewBag.Title = article.Title;
                ViewBag.ArticleDescription = article.SeoDescription;
                ViewBag.ArticleKeywords = article.SeoTags;
                ViewBag.ArticleAuthor = article.SeoAuthor;
                return View(article);
            }

            return NotFound(404);
        }
    }
}
