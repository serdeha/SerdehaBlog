namespace SerdehaBlog.WebUI.Dtos.CommentDto
{
    public class AddCommentDto
    {
        public string? Text { get; set; }
        public string? CreatedByName { get; set; }
        public int ArticleId { get; set; }
    }
}
