using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(SerdehaBlogDbContext context) : base(context)
        {
        }
    }
}
