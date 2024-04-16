using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfAboutRepository : BaseRepository<About>, IAboutRepository
    {
        private readonly SerdehaBlogDbContext _serdehaBlogDbContext;
        public EfAboutRepository(SerdehaBlogDbContext context, SerdehaBlogDbContext serdehaBlogDbContext) : base(context)
        {
            _serdehaBlogDbContext = serdehaBlogDbContext;
        }

        public async Task<About?> GetAbout()
        {
            return await _serdehaBlogDbContext.About.FirstOrDefaultAsync();
        }
    }
}
