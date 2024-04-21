using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Absract
{
	public interface IContactRepository : IBaseRepository<Contact>
	{
        Task<Contact?> GetContact();
    }
}
