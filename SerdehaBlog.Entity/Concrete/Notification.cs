using SerdehaBlog.Entity.Absract;

namespace SerdehaBlog.Entity.Concrete
{
    public class Notification : EntityBase, IEntity
    {
        public string? Title { get; set; }
        public string? NotificationIcon { get; set; }
        public int CommentId { get; set; } = 0;
        public bool IsRead { get; set; } = false;
    }
}
