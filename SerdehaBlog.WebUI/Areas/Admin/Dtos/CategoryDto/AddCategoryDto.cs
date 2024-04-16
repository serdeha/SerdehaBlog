namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.CategoryDto
{
    public class AddCategoryDto
    {
        public string? Name { get; set; }
        public string? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public int AppUserId { get; set; }
    }
}
