using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfAboutRepository : BaseRepository<About>, IAboutRepository
    {
        public EfAboutRepository(SerdehaBlogDbContext context) : base(context)
        {
        }
    }
}
