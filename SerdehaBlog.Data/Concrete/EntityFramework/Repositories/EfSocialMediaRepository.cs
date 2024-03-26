using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfSocialMediaRepository : BaseRepository<SocialMedia>, ISocialMediaRepository
    {
        public EfSocialMediaRepository(SerdehaBlogDbContext context) : base(context)
        {
        }
    }
}
