using SerdehaBlog.Business.Absract;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Notification entity)
        {
            if (entity != null)
            {
                _unitOfWork.Notification.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> AddAsync(Notification entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Notification.AddAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Delete(Notification entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Notification.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> DeleteAsync(Notification entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.Notification.UpdateAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public List<Notification> GetAll(Expression<Func<Notification, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Notification.GetAll() : _unitOfWork.Notification.GetAll(filter);
        }

        public List<Notification> GetAllWithFilter(Expression<Func<Notification, bool>>? predicate = null, params Expression<Func<Notification, object>>[] includeProperties)
        {
            return _unitOfWork.Notification.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Notification>> GetAllWithFilterAsync(Expression<Func<Notification, bool>>? predicate = null, params Expression<Func<Notification, object>>[] includeProperties)
        {
            return await _unitOfWork.Notification.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Notification? GetById(int entityId)
        {
            return _unitOfWork.Notification.GetById(x => x.Id == entityId);
        }

        public async Task<Notification?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Notification.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Notification, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Notification.GetCount() : _unitOfWork.Notification.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<Notification, bool>>? filter = null)
        {
            return filter == null ? await _unitOfWork.Notification.GetCountAsync() : await _unitOfWork.Notification.GetCountAsync(filter);
        }

        public Notification? GetWithFilter(Expression<Func<Notification, bool>>? predicate = null, params Expression<Func<Notification, object>>[] includeProperties)
        {
            return _unitOfWork.Notification.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Notification?> GetWithFilterAsync(Expression<Func<Notification, bool>>? predicate = null, params Expression<Func<Notification, object>>[] includeProperties)
        {
            return await _unitOfWork.Notification.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Notification entity)
        {
            if (entity != null)
            {
                _unitOfWork.Notification.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Notification entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Notification.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }
            return 0;
        }

        public void Update(Notification entity)
        {
            if (entity != null)
            {
                _unitOfWork.Notification.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> UpdateAsync(Notification entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Notification.UpdateAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }
            return 0;
        }
    }
}
