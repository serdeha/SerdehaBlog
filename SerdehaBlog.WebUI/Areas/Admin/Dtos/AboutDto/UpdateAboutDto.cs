namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.AboutDto
{
	public class UpdateAboutDto
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Text { get; set; }
		public string? ImagePath { get; set; }
		public string? ModifiedByName { get; set; } 
		public DateTime ModifiedDate { get; set; }
		public string? CreatedByName { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
