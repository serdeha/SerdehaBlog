using SerdehaBlog.Entity.Absract;

namespace SerdehaBlog.Entity.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public string? Text { get; set; }
        public string? IpAddress { get; set; } = "";

        public Article? Article { get; set; }
        public int ArticleId { get; set; }
        public List<ReplyComment>? ReplyComments { get; set; }
    }
}
