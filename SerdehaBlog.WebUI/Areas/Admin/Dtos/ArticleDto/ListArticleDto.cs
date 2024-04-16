namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.ArticleDto
{
    public class ListArticleDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CategoryName { get; set; }
        public string? ThumbnailPath { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public bool IsCarousel { get; set; }
    }
}
