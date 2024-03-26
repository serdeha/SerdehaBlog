namespace SerdehaBlog.WebUI.Dtos.ArticleDto
{
	public class CarouselArticleDto
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? ThumbnailPath { get; set; }
		public DateTime Date { get; set; }
		public string? CreatedByName { get; set; }
		public string? CategoryName { get; set; }
		public string? CategoryId { get; set; }
	}
}
