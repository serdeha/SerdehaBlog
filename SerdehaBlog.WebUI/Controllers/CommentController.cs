using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using SerdehaBlog.Business.Validations;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.CommentDto;
using SerdehaBlog.WebUI.Dtos.ReplyCommentDto;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Business.Absract;

namespace SerdehaBlog.WebUI.Controllers
{
	public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IReplyCommentService _replyCommentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IReplyCommentService replyCommentServic, IMapper mapper)
        {
            _commentService = commentService;
            _replyCommentService = replyCommentServic;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<JsonResult> Add(AddCommentDto addCommentDto)
        {
            Comment comment = _mapper.Map<Comment>(addCommentDto);
            CommentValidator validator = new CommentValidator();
            ValidationResult result = await validator.ValidateAsync(comment);
            if (result.IsValid)
            {
                comment.IpAddress = Request.HttpContext.Connection.RemoteIpAddress!.ToString();
                _commentService.Add(comment);
                return Json(new { ResultStatus = true, Data = comment }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                });
            }
            return Json(new { ResultStatus = false });
        }

        [HttpPost]
        public async Task<JsonResult> ReplyComment(AddReplyCommentDto addReplyCommentDto)
        {
            ReplyComment replyComment = _mapper.Map<ReplyComment>(addReplyCommentDto);
            ReplyCommentValidator validator = new ReplyCommentValidator();
            ValidationResult result = await validator.ValidateAsync(replyComment);
            if(result.IsValid)
            {
                replyComment.IpAddress = Request.HttpContext.Connection.RemoteIpAddress!.ToString();
                _replyCommentService.Add(replyComment);
				return Json(new { ResultStatus = true, Data = replyComment }, new JsonSerializerOptions
				{
					ReferenceHandler = ReferenceHandler.Preserve
				});
			}

            return Json(new { ResultStatus = false });
        }
    }
}
