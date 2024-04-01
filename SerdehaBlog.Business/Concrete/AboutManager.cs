using SerdehaBlog.Business.Absract;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AboutManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(About entity)
        {
            if(entity != null)
            {
                _unitOfWork.About.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> AddAsync(About entity)
        {
            if(entity != null)
            {
                await _unitOfWork.About.AddAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Delete(About entity)
        {
            if(entity != null )
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.About.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> DeleteAsync(About entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.About.UpdateAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public List<About> GetAll(Expression<Func<About, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.About.GetAll() : _unitOfWork.About.GetAll(filter);
        }

        public List<About> GetAllWithFilter(Expression<Func<About, bool>>? predicate = null, params Expression<Func<About, object>>[] includeProperties)
        {
           return _unitOfWork.About.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<About>> GetAllWithFilterAsync(Expression<Func<About, bool>>? predicate = null, params Expression<Func<About, object>>[] includeProperties)
        {
            return await _unitOfWork.About.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public About? GetById(int entityId)
        {
            return _unitOfWork.About.GetById(x => x.Id == entityId);
        }

        public async Task<About?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.About.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<About, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.About.GetCount() : _unitOfWork.About.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<About, bool>>? filter = null)
        {
            return filter == null ? await _unitOfWork.About.GetCountAsync() : await _unitOfWork.About.GetCountAsync(filter);
        }

        public About? GetWithFilter(Expression<Func<About, bool>>? predicate = null, params Expression<Func<About, object>>[] includeProperties)
        {
            return _unitOfWork.About.GetWithFilter(predicate, includeProperties);
        }

        public async Task<About?> GetWithFilterAsync(Expression<Func<About, bool>>? predicate = null, params Expression<Func<About, object>>[] includeProperties)
        {
            return await _unitOfWork.About.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(About entity)
        {
            if(entity != null)
            {
                _unitOfWork.About.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(About entity)
        {
            if(entity != null)
            {
                await _unitOfWork.About.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(About entity)
        {
            if(entity != null)
            {
                _unitOfWork.About.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> UpdateAsync(About entity)
        {
            if (entity != null)
            {
                await _unitOfWork.About.UpdateAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }
    }
}
