using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.WebUI.Dtos.ArticleDto;

namespace SerdehaBlog.WebUI.ViewComponents.CarouselPost
{
	public class CarouselPostViewComponent : ViewComponent
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CarouselPostViewComponent(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<CarouselArticleDto> carouselArticles = _mapper.Map<List<CarouselArticleDto>>(await _unitOfWork.Article.GetCarouselArticleAsync(x => x.IsActive && !x.IsDeleted && x.IsCarousel, x => x.Category!));
			return View(carouselArticles);
		}
	}
}
