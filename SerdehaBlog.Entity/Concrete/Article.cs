using SerdehaBlog.Entity.Absract;

namespace SerdehaBlog.Entity.Concrete
{
    public class Article : EntityBase, IEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ThumbnailPath { get; set; }
        public DateTime Date { get; set; }
        public int ViewCount { get; set; } = 0;
        public string? SeoAuthor { get; set; }
        public string? SeoDescription { get; set; }
        public string? SeoTags { get; set; }
        public bool IsCorousel { get; set; }

        public AppUser? AppUser { get; set; }
        public int AppUserId { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
