using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfNotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public EfNotificationRepository(SerdehaBlogDbContext context) : base(context)
        {
        }
    }
}
