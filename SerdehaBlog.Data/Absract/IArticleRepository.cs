using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Data.Absract
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        Task<List<Article>> GetLastThreeArticleAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties);
        Task<List<Article>> GetCarouselArticleAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties);
    }
}
