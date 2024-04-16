namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.ArticleDto
{
    public class AddArticleDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ThumbnailPath { get; set; }
        public string? SeoAuthor { get; set; }
        public string? SeoDescription { get; set; }
        public string? SeoTags { get; set; }
        public string? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public int AppUserId { get; set; }
        public bool IsCarousel { get; set; }
    }
}
