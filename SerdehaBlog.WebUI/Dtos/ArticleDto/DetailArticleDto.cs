namespace SerdehaBlog.WebUI.Dtos.ArticleDto
{
    public class DetailArticleDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
		public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ThumbnailPath { get; set; }
        public DateTime Date { get; set; }
        public string? CreatedByName { get; set; }
        public string? CategoryName { get; set; }
        public string? SeoAuthor { get; set; }
        public string? SeoDescription { get; set; }
        public string? SeoTags { get; set; }
    }
}
