using SerdehaBlog.Entity.Absract;

namespace SerdehaBlog.Entity.Concrete
{
    public class ReplyComment : EntityBase, IEntity
    {
        public string? Text { get; set; }
        public string? IpAddress { get; set; } = "";

        public Comment? Comment { get; set; }
        public int CommentId { get; set; }
    }
}
