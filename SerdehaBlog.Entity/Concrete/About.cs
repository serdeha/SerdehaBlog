using SerdehaBlog.Entity.Absract;

namespace SerdehaBlog.Entity.Concrete
{
    public class About : EntityBase, IEntity
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? ImagePath { get; set; }
    }
}
