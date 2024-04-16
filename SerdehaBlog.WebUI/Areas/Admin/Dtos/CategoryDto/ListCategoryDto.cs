namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.CategoryDto
{
    public class ListCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ArticleCount { get; set; }
        public bool IsActive { get; set; }
    }
}
