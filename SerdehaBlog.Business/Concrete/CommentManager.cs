using SerdehaBlog.Business.Absract;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Comment entity)
        {
            if(entity != null)
            {
                _unitOfWork.Comment.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(Comment entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Comment.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(Comment entity)
        {
            if(entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Comment.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task DeleteAsync(Comment entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.Comment.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Comment.GetAll() : _unitOfWork.Comment.GetAll(filter);
        }

        public List<Comment> GetAllWithFilter(Expression<Func<Comment, bool>>? predicate = null, params Expression<Func<Comment, object>>[] includeProperties)
        {
            return _unitOfWork.Comment.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Comment>> GetAllWithFilterAsync(Expression<Func<Comment, bool>>? predicate = null, params Expression<Func<Comment, object>>[] includeProperties)
        {
            return await _unitOfWork.Comment.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Comment? GetById(int entityId)
        {
            return _unitOfWork.Comment.GetById(x => x.Id == entityId);
        }

        public async Task<Comment?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Comment.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Comment, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Comment.GetCount() : _unitOfWork.Comment.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<Comment, bool>>? filter = null)
        {
            return filter == null ? await _unitOfWork.Comment.GetCountAsync() : await _unitOfWork.Comment.GetCountAsync(filter);
        }

        public Comment? GetWithFilter(Expression<Func<Comment, bool>>? predicate = null, params Expression<Func<Comment, object>>[] includeProperties)
        {
            return _unitOfWork.Comment.GetWithFilter(predicate, includeProperties); 
        }

        public async Task<Comment?> GetWithFilterAsync(Expression<Func<Comment, bool>>? predicate = null, params Expression<Func<Comment, object>>[] includeProperties)
        {
            return await _unitOfWork.Comment.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Comment entity)
        {
            if(entity != null)
            {
                _unitOfWork.Comment.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Comment entity)
        {
           if(entity != null)
            {
                await _unitOfWork.Comment.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Comment entity)
        {
            if(entity != null)
            {
                _unitOfWork.Comment.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(Comment entity)
        {
           if(entity != null)
            {
                await _unitOfWork.Comment.UpdateAsync(entity); 
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
