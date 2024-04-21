using SerdehaBlog.Entity.Absract;

namespace SerdehaBlog.Entity.Concrete
{
	public class Contact : EntityBase, IEntity
	{
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Subject { get; set; }
		public string? Text { get; set; }
        public bool IsRead { get; set; }
    }
}
