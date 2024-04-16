using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Repositories
{
	public class EfArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly SerdehaBlogDbContext _serdehaBlogDbContext;
        public EfArticleRepository(SerdehaBlogDbContext context, SerdehaBlogDbContext serdehaBlogDbContext) : base(context)
        {
            _serdehaBlogDbContext = serdehaBlogDbContext;
        }

        public IEnumerable<Article> GetAllArticlesWithPagination(string searchValue, string sortColumn, string sortDirectory, int pageSize, int skipRecords)
        {
            IEnumerable<Article> articles = _serdehaBlogDbContext.Articles.Where(x => x.IsActive && !x.IsDeleted
            || x.Title!.Contains(searchValue)
            || x.Category!.Name!.Contains(searchValue)
            ).Include(x => x.Category)
            .AsEnumerable<Article>();

            if (sortDirectory == "asc")
                articles = articles.OrderBy(x => x.GetType().GetProperty(sortColumn)!.GetValue(x));
            else
                articles = articles.OrderByDescending(x => x.GetType().GetProperty(sortColumn)!.GetValue(x));

            articles = articles.Skip(skipRecords).Take(pageSize);

            return articles;
        }

        public async Task<List<Article>> GetCarouselArticleAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties)
		{
            IQueryable<Article> query = _serdehaBlogDbContext.Articles;

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }


			return await query.OrderByDescending(x=>x.Date).ToListAsync();
		}

		public async Task<List<Article>> GetLastThreeArticleAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties)
        {
            IQueryable<Article> query = _serdehaBlogDbContext.Articles;

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.OrderByDescending(x=>x.Date).Skip(Math.Max(0, query.Count() - 3)).ToListAsync();
        }
    }
}
