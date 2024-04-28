using SerdehaBlog.Business.Absract;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Category entity)
        {
            if (entity != null)
            {
                _unitOfWork.Category.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> AddAsync(Category entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Category.AddAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Delete(Category entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Category.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> DeleteAsync(Category entity, DateTime modifiedDate, string modifiedByName)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                entity.ModifiedDate = modifiedDate;
                entity.ModifiedByName = modifiedByName;
                await _unitOfWork.Category.DeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>>? filter = null)
        {
            return filter == null ?
                 _unitOfWork.Category.GetAll() :
                 _unitOfWork.Category.GetAll(filter);
        }

        public List<Category> GetAllWithFilter(Expression<Func<Category, bool>>? predicate = null, params Expression<Func<Category, object>>[] includeProperties)
        {
            return _unitOfWork.Category.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Category>> GetAllWithFilterAsync(Expression<Func<Category, bool>>? predicate = null, params Expression<Func<Category, object>>[] includeProperties)
        {
            return await _unitOfWork.Category.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Category? GetById(int entityId)
        {
            return _unitOfWork.Category.GetById(x => x.Id == entityId);
        }

        public async Task<Category?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Category.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Category, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Category.GetCount() :
                _unitOfWork.Category.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<Category, bool>>? filter = null)
        {
            return filter == null ?
                await _unitOfWork.Category.GetCountAsync() :
                await _unitOfWork.Category.GetCountAsync(filter);
        }

        public Category? GetWithFilter(Expression<Func<Category, bool>>? predicate = null, params Expression<Func<Category, object>>[] includeProperties)
        {
            return _unitOfWork.Category.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Category?> GetWithFilterAsync(Expression<Func<Category, bool>>? predicate = null, params Expression<Func<Category, object>>[] includeProperties)
        {
            return await _unitOfWork.Category.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Category entity)
        {
            if (entity != null)
            {
                _unitOfWork.Category.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Category entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Category.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Category entity)
        {
           if(entity != null)
            {
                _unitOfWork.Category.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> UpdateAsync(Category entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Category.UpdateAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }
    }
}
