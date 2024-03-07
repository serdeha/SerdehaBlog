using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfReplyCommentRepository : BaseRepository<ReplyComment>, IReplyCommentRepository
    {
        public EfReplyCommentRepository(SerdehaBlogDbContext context) : base(context)
        {
        }
    }
}
