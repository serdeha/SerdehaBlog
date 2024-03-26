using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.WebUI.Dtos.CommentDto;

namespace SerdehaBlog.WebUI.ViewComponents.Comment
{
    public class CommentListViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentListViewComponent(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int articleId, int commentPage = 1)
        {
            List<ListCommentDto> comments = _mapper.Map<List<ListCommentDto>>(await _unitOfWork.Comment.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.ArticleId == articleId, x => x.ReplyComments!));
            return View(comments);
        }
    }
}
