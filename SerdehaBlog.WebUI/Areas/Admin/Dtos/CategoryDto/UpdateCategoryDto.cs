namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int AppUserId { get; set; }
    }
}
