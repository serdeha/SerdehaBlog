using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Absract
{
    public interface IArticleService : IBaseService<Article>
    {
        Task<List<Article>> GetLastThreeArticleAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties);
		Task<List<Article>> GetCarouselArticleAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties);
        IEnumerable<Article> GetAllArticlesWithPagination(string searchValue, string sortColumn, string sortDirectory, int pageSize, int skipRecords);
    }
}
