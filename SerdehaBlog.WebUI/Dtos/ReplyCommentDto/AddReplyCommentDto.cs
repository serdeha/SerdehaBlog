using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.WebUI.Dtos.ReplyCommentDto
{
	public class AddReplyCommentDto
	{
		public int CommentId { get; set; }
		public string? CreatedByName { get; set; }
		public string? Text { get; set; }
		public string? IpAddress { get; set; } = "";		
	}
}
