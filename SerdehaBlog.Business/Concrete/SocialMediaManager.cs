using SerdehaBlog.Business.Absract;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SocialMediaManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(SocialMedia entity)
        {
            if (entity != null)
            {
                _unitOfWork.SocialMedia.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> AddAsync(SocialMedia entity)
        {
            if (entity != null)
            {
                await _unitOfWork.SocialMedia.AddAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Delete(SocialMedia entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.SocialMedia.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> DeleteAsync(SocialMedia entity, DateTime modifiedDate, string modifiedByName)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                entity.ModifiedDate = modifiedDate;
                entity.ModifiedByName = modifiedByName;
                await _unitOfWork.SocialMedia.UpdateAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public List<SocialMedia> GetAll(Expression<Func<SocialMedia, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.SocialMedia.GetAll() :
                _unitOfWork.SocialMedia.GetAll(filter);
        }

        public List<SocialMedia> GetAllWithFilter(Expression<Func<SocialMedia, bool>>? predicate = null, params Expression<Func<SocialMedia, object>>[] includeProperties)
        {
            return _unitOfWork.SocialMedia.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<SocialMedia>> GetAllWithFilterAsync(Expression<Func<SocialMedia, bool>>? predicate = null, params Expression<Func<SocialMedia, object>>[] includeProperties)
        {
            return await _unitOfWork.SocialMedia.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public SocialMedia? GetById(int entityId)
        {
            return _unitOfWork.SocialMedia.GetById(x => x.Id == entityId);
        }

        public async Task<SocialMedia?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.SocialMedia.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<SocialMedia, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.SocialMedia.GetCount() :
                _unitOfWork.SocialMedia.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<SocialMedia, bool>>? filter = null)
        {
            return filter == null ?
                await _unitOfWork.SocialMedia.GetCountAsync() :
                await _unitOfWork.SocialMedia.GetCountAsync(filter);
        }

        public SocialMedia? GetWithFilter(Expression<Func<SocialMedia, bool>>? predicate = null, params Expression<Func<SocialMedia, object>>[] includeProperties)
        {
            return _unitOfWork.SocialMedia.GetWithFilter(predicate, includeProperties);
        }

        public async Task<SocialMedia?> GetWithFilterAsync(Expression<Func<SocialMedia, bool>>? predicate = null, params Expression<Func<SocialMedia, object>>[] includeProperties)
        {
            return await _unitOfWork.SocialMedia.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(SocialMedia entity)
        {
            if(entity != null)
            {
                _unitOfWork.SocialMedia.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(SocialMedia entity)
        {
            if(entity != null)
            {
                await _unitOfWork.SocialMedia.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(SocialMedia entity)
        {
            if(entity != null)
            {
                _unitOfWork.SocialMedia.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> UpdateAsync(SocialMedia entity)
        {
            if (entity != null)
            {
                await _unitOfWork.SocialMedia.UpdateAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }
    }
}
