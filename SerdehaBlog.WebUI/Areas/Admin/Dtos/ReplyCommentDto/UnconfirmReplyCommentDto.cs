namespace SerdehaBlog.WebUI.Areas.Admin.Dtos.ReplyCommentDto
{
    public class UnconfirmReplyCommentDto
    {
        public int Id { get; set; }
        public string? CommentName { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
