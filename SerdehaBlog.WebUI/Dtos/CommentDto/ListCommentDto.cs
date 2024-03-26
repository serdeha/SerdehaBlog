using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.WebUI.Dtos.CommentDto
{
    public class ListCommentDto
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ArticleId { get; set; }
        public List<ReplyComment>? ReplyComments { get; set; }
    }
}
