using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.CommentDto;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Route("/Admin/Yorumlar/")]
        [Route("/Admin/Comment/Index/")]
        [Route("/Admin/Comment/")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetComments()
        {
            List<ListCommentDto> commentList = _mapper.Map<List<ListCommentDto>>(await _commentService.GetAllWithFilterAsync(x => !x.IsDeleted, x => x.Article!, x => x.ReplyComments!));
            if (commentList.Any())
            {
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = commentList }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        [Route("/Admin/Yorum/Detay/{yorumId?}")]
        [Route("/Admin/Comment/Detail/{yorumId?}")]
        public async Task<IActionResult> Detail(int commentId)
        {
            TempData["CommentId"] = commentId;
            DetailCommentDto comment = _mapper.Map<DetailCommentDto>(await _commentService.GetWithFilterAsync(x => !x.IsDeleted && x.Id == commentId, x => x.Article!, x => x.ReplyComments!));
            return comment != null ? View(comment) : NotFound(404);
        }

        public async Task<JsonResult> Delete(int commentId)
        {
            var comment = await _commentService.GetByIdAsync(commentId);
            if (comment != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _commentService.DeleteAsync(comment, DateTime.Now, string.Concat(user!.FirstName, " ", user.LastName));
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = comment }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> Confirm(int commentId)
        {
            var comment = await _commentService.GetWithFilterAsync(x => !x.IsDeleted && x.Id == commentId, x => x.Article!, x => x.ReplyComments!);

            if (comment != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                comment.ModifiedDate = DateTime.Now;
                comment.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                comment.IsActive = true;
                await _commentService.UpdateAsync(comment);
                ConfirmCommentDto commentDto = _mapper.Map<ConfirmCommentDto>(comment);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = commentDto }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> UnConfirm(int commentId)
        {
            var comment = await _commentService.GetWithFilterAsync(x => !x.IsDeleted && x.Id == commentId, x => x.Article!, x => x.ReplyComments!);

            if (comment != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                comment.ModifiedDate = DateTime.Now;
                comment.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                comment.IsActive = false;
                await _commentService.UpdateAsync(comment);
                UnconfirmCommentDto commentDto = _mapper.Map<UnconfirmCommentDto>(comment);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = commentDto }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }
    }
}
