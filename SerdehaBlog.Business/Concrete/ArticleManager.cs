﻿using SerdehaBlog.Business.Absract;
using SerdehaBlog.Data.UnitOfWork;
using SerdehaBlog.Entity.Concrete;
using System.Linq.Expressions;

namespace SerdehaBlog.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Article entity)
        {
            if(entity != null)
            {
                _unitOfWork.Article.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> AddAsync(Article entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Article.AddAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Delete(Article entity)
        {
            if(entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Article.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> DeleteAsync(Article entity, DateTime modifiedDate, string modifiedByName)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                entity.ModifiedDate = modifiedDate;
                entity.ModifiedByName = modifiedByName;
                await _unitOfWork.Article.DeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public List<Article> GetAll(Expression<Func<Article, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Article.GetAll() : _unitOfWork.Article.GetAll(filter);
        }

        public List<Article> GetAllWithFilter(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties)
        {
            return _unitOfWork.Article.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Article>> GetAllWithFilterAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties)
        {
            return await _unitOfWork.Article.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Article? GetById(int entityId)
        {
            return _unitOfWork.Article.GetById(x=>x.Id == entityId);
        }

        public async Task<Article?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Article.GetByIdAsync(x=>x.Id == entityId);
        }

		public async Task<List<Article>> GetCarouselArticleAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties)
		{
            return await _unitOfWork.Article.GetCarouselArticleAsync(predicate, includeProperties);
		}

		public int GetCount(Expression<Func<Article, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Article.GetCount() : _unitOfWork.Article.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<Article, bool>>? filter = null)
        {
            return filter == null ? await _unitOfWork.Article.GetCountAsync() : await _unitOfWork.Article.GetCountAsync(filter);
        }

        public Task<List<Article>> GetLastThreeArticleAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties)
        {
            return _unitOfWork.Article.GetLastThreeArticleAsync(predicate, includeProperties);
        }

        public Article? GetWithFilter(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties)
        {
            return _unitOfWork.Article.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Article?> GetWithFilterAsync(Expression<Func<Article, bool>>? predicate = null, params Expression<Func<Article, object>>[] includeProperties)
        {
            return await _unitOfWork.Article.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Article entity)
        {
            if(entity != null)
            {
                _unitOfWork.Article.HardDelete(entity);
            }
        }

        public async Task<int> HardDeleteAsync(Article entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Article.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Article entity)
        {
            if(entity != null)
            {
                _unitOfWork.Article.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> UpdateAsync(Article entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Article.UpdateAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }
    }
}
