using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.WebUI.Dtos.CommentDto;

namespace SerdehaBlog.WebUI.ViewComponents.Comment
{
    public class CommentListViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly IReplyCommentService _replyCommentService;
        private readonly IMapper _mapper;

        public CommentListViewComponent(ICommentService commentService, IReplyCommentService replyCommentService, IMapper mapper)
        {
            _commentService = commentService;
            _replyCommentService = replyCommentService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int articleId, int commentPage = 1)
        {
            int replyCount = 0;
            List<ListCommentDto> comments = _mapper.Map<List<ListCommentDto>>(await _commentService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted && x.ArticleId == articleId, x => x.ReplyComments!));
            comments.ForEach(comment =>
            {
                comment.ReplyComments = comment.ReplyComments!.Where(reply => reply.IsActive && !reply.IsDeleted).ToList();
                replyCount += comment.ReplyComments.Count;
            });

            ViewBag.MessageCount = comments.Count + replyCount;
            return View(comments);
        }
    }
}
