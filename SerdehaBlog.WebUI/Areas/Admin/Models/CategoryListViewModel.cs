using Microsoft.AspNetCore.Mvc.Rendering;

namespace SerdehaBlog.WebUI.Areas.Admin.Models
{
    public class CategoryListViewModel
    {
        public List<SelectListItem>? CategoryList { get; set; }
    }
}
