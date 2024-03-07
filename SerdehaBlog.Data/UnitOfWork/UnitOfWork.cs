﻿using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Contexts;
using SerdehaBlog.Data.Concrete.EntityFramework.Repositories;

namespace SerdehaBlog.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SerdehaBlogDbContext _context;
        private EfArticleRepository? _articleRepository;
        private EfCategoryRepository? _categoryRepository;
        private EfCommentRepository? _commentRepository;
        private EfReplyCommentRepository? _replyCommentRepository;

        public UnitOfWork(SerdehaBlogDbContext context)
        {
            _context = context;
        }

        public IArticleRepository Article => _articleRepository ??= new EfArticleRepository(_context);
        public ICategoryRepository Category => _categoryRepository ??= new EfCategoryRepository(_context);
        public ICommentRepository Comment => _commentRepository ??= new EfCommentRepository(_context);
        public IReplyCommentRepository ReplyComment => _replyCommentRepository ??= new EfReplyCommentRepository(_context);

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
