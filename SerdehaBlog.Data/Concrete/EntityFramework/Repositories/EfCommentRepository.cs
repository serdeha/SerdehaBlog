using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfCommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public EfCommentRepository(SerdehaBlogDbContext context) : base(context)
        {
        }
    }
}
