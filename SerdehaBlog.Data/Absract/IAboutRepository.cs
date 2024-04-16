using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Absract
{
    public interface IAboutRepository : IBaseRepository<About>
    {
        Task<About?> GetAbout();
    }
}
