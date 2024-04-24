using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.CommentDto
{
    public class DetailCommentDto
    {
        public int Id { get; set; }
        public string? ArticleTitle { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Text { get; set; }
        public bool IsActive { get; set; }
        public int ArticleId { get; set; }
    }
}
