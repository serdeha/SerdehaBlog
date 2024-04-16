using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Absract
{
    public interface IAboutService : IBaseService<About>
    {
        Task<About?> GetAbout();
    }
}
