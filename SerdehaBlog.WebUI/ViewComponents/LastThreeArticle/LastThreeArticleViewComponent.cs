using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.WebUI.Dtos.ArticleDto;

namespace SerdehaBlog.WebUI.ViewComponents.LastFourArticle
{
    public class LastThreeArticleViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LastThreeArticleViewComponent(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ListArticleDto> lastFourArticles = _mapper.Map<List<ListArticleDto>>(await _unitOfWork.Article.GetLastThreeArticleAsync(x => x.IsActive && !x.IsDeleted));
            return View(lastFourArticles);
        }
    }
}
