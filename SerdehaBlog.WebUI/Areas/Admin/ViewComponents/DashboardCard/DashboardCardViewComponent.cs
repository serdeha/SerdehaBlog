
using Microsoft.AspNetCore.Mvc;
using SerdehaBlog.Business.Absract;

namespace SerdehaBlog.WebUI.Areas.Admin.ViewComponents.DashboardCard
{
    public class DashboardCardViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IContactService _contactService;

        public DashboardCardViewComponent(IArticleService articleService, ICategoryService categoryService, ICommentService commentService, IContactService contactService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _commentService = commentService;
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.ArticleCount = await _articleService.GetCountAsync(x=>x.IsActive && !x.IsDeleted);
            ViewBag.CategoryCount = await _categoryService.GetCountAsync(x => x.IsActive && !x.IsDeleted);
            ViewBag.CommentCount = await _commentService.GetCountAsync(x => x.IsActive && !x.IsDeleted);
            ViewBag.ContactCount = await _contactService.GetCountAsync(x => x.IsActive && !x.IsDeleted);
            return View();
        }
    }
}
