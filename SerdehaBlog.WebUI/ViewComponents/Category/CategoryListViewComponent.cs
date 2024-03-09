using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.WebUI.Dtos.CategoryDto;

namespace SerdehaBlog.WebUI.ViewComponents.Category
{
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryListViewComponent(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ListCategoryDto> categories = _mapper.Map<List<ListCategoryDto>>(await _unitOfWork.Category.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted));
            return View(categories);
        }
    }
}
