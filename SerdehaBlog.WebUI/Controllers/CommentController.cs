using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using SerdehaBlog.Business.Validations;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.CommentDto;
using SerdehaBlog.WebUI.Dtos.ReplyCommentDto;
using SerdehaBlog.Business.Absract;
using Microsoft.AspNetCore.Authorization;

namespace SerdehaBlog.WebUI.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IReplyCommentService _replyCommentService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IReplyCommentService replyCommentServic, INotificationService notificationService, IMapper mapper)
        {
            _commentService = commentService;
            _replyCommentService = replyCommentServic;
            _notificationService = notificationService;
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
                comment.IsActive = false;
                await _commentService.AddAsync(comment);

                await _notificationService.AddAsync(new Notification
                {
                    Title = $"{comment.CreatedByName} Bir Yorum Bıraktı!",
                    NotificationIcon = "icon-speech",
                    CommentId = comment.Id
                });

                return Json(new { ResultStatus = true, Data = comment }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                });
            }


            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += $"*{error.ErrorMessage}<br>";
            }

            return Json(new { ResultStatus = false, ErrorMessages = errors });
        }

        [HttpPost]
        public async Task<JsonResult> ReplyComment(AddReplyCommentDto addReplyCommentDto)
        {
            ReplyComment replyComment = _mapper.Map<ReplyComment>(addReplyCommentDto);
            ReplyCommentValidator validator = new ReplyCommentValidator();
            ValidationResult result = await validator.ValidateAsync(replyComment);
            if (result.IsValid)
            {
                replyComment.IpAddress = Request.HttpContext.Connection.RemoteIpAddress!.ToString();
                replyComment.IsActive = false;
                await _replyCommentService.AddAsync(replyComment);

                await _notificationService.AddAsync(new Notification
                {
                    Title = $"{replyComment.CreatedByName} Bir Yorum Bıraktı!",
                    NotificationIcon = "icon-speech",
                    CommentId = replyComment.CommentId
                });

                return Json(new { ResultStatus = true, Data = replyComment }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                });
            }

            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += $"*{error.ErrorMessage}<br>";
            }

            return Json(new { ResultStatus = false, ErrorMessages = errors });
        }
    }
}
