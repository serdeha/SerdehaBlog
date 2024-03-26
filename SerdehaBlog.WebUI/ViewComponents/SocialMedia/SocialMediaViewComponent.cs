using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.WebUI.Dtos.SocialMediaDto;

namespace SerdehaBlog.WebUI.ViewComponents.SocialMedia
{
    public class SocialMediaViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public SocialMediaViewComponent(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ListSocialMediaDto> socialMedias = _mapper.Map<List<ListSocialMediaDto>>(await _unitOfWork.SocialMedia.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.Status));
            return View(socialMedias);
        }
    }
}
