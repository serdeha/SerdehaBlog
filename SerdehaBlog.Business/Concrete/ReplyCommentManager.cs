using SerdehaBlog.Business.Absract;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Concrete
{
    public class ReplyCommentManager : IReplyCommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReplyCommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ReplyComment entity)
        {
            if (entity != null)
            {
                _unitOfWork.ReplyComment.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(ReplyComment entity)
        {
            if (entity != null)
            {
                await _unitOfWork.ReplyComment.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(ReplyComment entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.ReplyComment.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task DeleteAsync(ReplyComment entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.ReplyComment.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public List<ReplyComment> GetAll(Expression<Func<ReplyComment, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.ReplyComment.GetAll() : _unitOfWork.ReplyComment.GetAll(filter);
        }

        public List<ReplyComment> GetAllWithFilter(Expression<Func<ReplyComment, bool>>? predicate = null, params Expression<Func<ReplyComment, object>>[] includeProperties)
        {
            return _unitOfWork.ReplyComment.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<ReplyComment>> GetAllWithFilterAsync(Expression<Func<ReplyComment, bool>>? predicate = null, params Expression<Func<ReplyComment, object>>[] includeProperties)
        {
            return await _unitOfWork.ReplyComment.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public ReplyComment? GetById(int entityId)
        {
            return _unitOfWork.ReplyComment.GetById(x => x.Id == entityId);
        }

        public async Task<ReplyComment?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.ReplyComment.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<ReplyComment, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.ReplyComment.GetCount() : _unitOfWork.ReplyComment.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<ReplyComment, bool>>? filter = null)
        {
            return filter == null ? await _unitOfWork.ReplyComment.GetCountAsync() : await _unitOfWork.ReplyComment.GetCountAsync(filter);
        }

        public ReplyComment? GetWithFilter(Expression<Func<ReplyComment, bool>>? predicate = null, params Expression<Func<ReplyComment, object>>[] includeProperties)
        {
            return _unitOfWork.ReplyComment.GetWithFilter(predicate, includeProperties);    
        }

        public Task<ReplyComment?> GetWithFilterAsync(Expression<Func<ReplyComment, bool>>? predicate = null, params Expression<Func<ReplyComment, object>>[] includeProperties)
        {
            return _unitOfWork.ReplyComment.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(ReplyComment entity)
        {
            if(entity != null)
            {
                _unitOfWork.ReplyComment.HardDelete(entity);
            }
        }

        public async Task<int> HardDeleteAsync(ReplyComment entity)
        {
            if( entity != null)
            {
                await _unitOfWork.ReplyComment.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(ReplyComment entity)
        {
            if(entity != null)
            {
                _unitOfWork.ReplyComment.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(ReplyComment entity)
        {
           if(entity != null)
            {
                await _unitOfWork.ReplyComment.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
