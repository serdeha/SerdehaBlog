namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.CommentDto
{
    public class UnconfirmCommentDto
    {
        public int Id { get; set; }
        public string? ArticleTitle { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int ReplyCommentCount { get; set; }
    }
}
