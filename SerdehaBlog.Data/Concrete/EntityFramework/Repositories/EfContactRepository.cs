using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
	public class EfContactRepository : BaseRepository<Contact>, IContactRepository
	{
        private readonly SerdehaBlogDbContext _serdehaBlogDbContext;
        public EfContactRepository(SerdehaBlogDbContext context, SerdehaBlogDbContext serdehaBlogDbContext) : base(context)
		{
            _serdehaBlogDbContext = serdehaBlogDbContext;
		}

        public async Task<Contact?> GetContact()
        {
            return await _serdehaBlogDbContext.Contacts.FirstOrDefaultAsync();
        }
    }
}
