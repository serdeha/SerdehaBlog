using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.ArticleDto;
using X.PagedList;

namespace SerdehaBlog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public BlogController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index(int? kategori, int sayfa = 1)
        {
            List<Article> article = kategori.HasValue ?
                await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.CategoryId == kategori.Value, x => x.Category!) :
                await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted, x => x.Category!);

            List<ListArticleDto> articleResults = _mapper.Map<List<ListArticleDto>>(article);

            return View(await articleResults.OrderByDescending(x => x.Date).ToPagedListAsync(sayfa, 3));
        }

        [Route("Blog/Ara/{kelime?}")]
        public async Task<IActionResult> Search(string kelime, int sayfa = 1)
        {
            List<Article> searchedArticles = string.IsNullOrEmpty(kelime) ?
                await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted, x => x.Category!) :
                await _articleService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.Content!.Contains(kelime), x => x.Category!);

            List<ListArticleDto> articleResults = _mapper.Map<List<ListArticleDto>>(searchedArticles);

            return View(await articleResults.OrderByDescending(x => x.Date).ToPagedListAsync(sayfa, 3));
        }

        public async Task<IActionResult> ReadMore(int articleId)
        {
            var article = _mapper.Map<DetailArticleDto>(await _articleService.GetWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.Id == articleId, x => x.Category!));

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
