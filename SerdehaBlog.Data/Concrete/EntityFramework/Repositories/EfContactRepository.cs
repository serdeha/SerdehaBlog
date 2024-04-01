using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
	public class EfContactRepository : BaseRepository<Contact>, IContactRepository
	{
		public EfContactRepository(SerdehaBlogDbContext context) : base(context)
		{
		}
	}
}
