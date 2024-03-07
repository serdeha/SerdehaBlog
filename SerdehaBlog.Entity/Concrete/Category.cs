using SerdehaBlog.Entity.Absract;

namespace SerdehaBlog.Entity.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public string? Name { get; set; }

        public AppUser? AppUser { get; set; }
        public int AppUserId { get; set; }

        public List<Article>? Articles { get; set; }
    }
}
