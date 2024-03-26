using SerdehaBlog.Entity.Absract;

namespace SerdehaBlog.Entity.Concrete
{
    public class SocialMedia : EntityBase, IEntity
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public bool Status { get; set; }
        public AppUser? AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
