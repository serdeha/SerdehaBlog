using SerdehaBlog.Entity.Absract;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Absract
{
    public interface IBaseService<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void HardDelete(T entity);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> HardDeleteAsync(T entity);
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        List<T> GetAllWithFilter(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllWithFilterAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T? GetWithFilter(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T?> GetWithFilterAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T? GetById(int entityId);
        Task<T?> GetByIdAsync(int entityId);
        int GetCount(Expression<Func<T, bool>>? filter = null);
        Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null);
    }
}
