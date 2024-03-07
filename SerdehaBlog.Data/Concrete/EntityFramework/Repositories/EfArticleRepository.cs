using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public EfArticleRepository(SerdehaBlogDbContext context) : base(context)
        {
        }
    }
}
