using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.CommentDto;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.ReplyCommentDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ReplyCommentController : Controller
    {
        private readonly IReplyCommentService _replyCommentService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public ReplyCommentController(IReplyCommentService replyCommentService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _replyCommentService = replyCommentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Detail(int replyCommentId)
        {
            DetailReplyCommentDto replyComment = _mapper.Map<DetailReplyCommentDto>(await _replyCommentService.GetWithFilterAsync(x => x.Id == replyCommentId && !x.IsDeleted, x => x.Comment!));
            return replyComment != null ? View(replyComment) : NotFound(404);
        }

        public async Task<JsonResult> GetReplyComments()
        {
            List<ListReplyCommentDto> replyComments = _mapper.Map<List<ListReplyCommentDto>>(await _replyCommentService.GetAllWithFilterAsync(x => x.CommentId == Convert.ToInt32(TempData["CommentId"]) && !x.IsDeleted, x => x.Comment!));
            if (replyComments.Any())
            {
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = replyComments }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> Confirm(int replyCommentId)
        {
            var replyComment = await _replyCommentService.GetWithFilterAsync(x => !x.IsDeleted && x.Id == replyCommentId, x => x.Comment!);

            if (replyComment != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                replyComment.ModifiedDate = DateTime.Now;
                replyComment.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                replyComment.IsActive = true;
                await _replyCommentService.UpdateAsync(replyComment);
                ConfirmReplyCommentDto replyCommentDto = _mapper.Map<ConfirmReplyCommentDto>(replyComment);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = replyCommentDto }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> UnConfirm(int replyCommentId)
        {
            var replyComment = await _replyCommentService.GetWithFilterAsync(x => !x.IsDeleted && x.Id == replyCommentId, x => x.Comment!);

            if (replyComment != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                replyComment.ModifiedDate = DateTime.Now;
                replyComment.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                replyComment.IsActive = false;
                await _replyCommentService.UpdateAsync(replyComment);
                UnconfirmReplyCommentDto replyCommentDto = _mapper.Map<UnconfirmReplyCommentDto>(replyComment);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = replyCommentDto }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }

        public async Task<JsonResult> Delete(int replyCommentId)
        {
            var replyComment = await _replyCommentService.GetByIdAsync(replyCommentId);
            if (replyComment != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                replyComment.ModifiedDate = DateTime.Now;
                replyComment.ModifiedByName = string.Concat(user!.FirstName, " ", user.LastName);
                replyComment.IsDeleted = true;
                replyComment.IsActive = false;
                await _replyCommentService.UpdateAsync(replyComment);
                return Json(JsonSerializer.Serialize(new { ResultStatus = true, Data = replyComment }, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                }));
            }

            return Json(JsonSerializer.Serialize(new { ResultStatus = false }));
        }
    }
}
