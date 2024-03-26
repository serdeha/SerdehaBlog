using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.ArticleDto;
using X.PagedList;

namespace SerdehaBlog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public async Task<IActionResult> Index(int? kategori, int sayfa = 1)
        {
            List<Article> article = kategori.HasValue ?
                await _unitOfWork.Article.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.CategoryId == kategori.Value, x => x.Category!) :
                await _unitOfWork.Article.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted, x => x.Category!);

            List<ListArticleDto> articleResults = _mapper.Map<List<ListArticleDto>>(article);

            return View(await articleResults.OrderByDescending(x=>x.Date).ToPagedListAsync(sayfa, 1));
        }

        public async Task<IActionResult> ReadMore(int articleId)
        {
            var article = _mapper.Map<DetailArticleDto>(await _unitOfWork.Article.GetWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.Id == articleId, x => x.Category!));

            if(article != null)
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
