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
		private EfSocialMediaRepository? _socialMediaRepository;
		private EfContactRepository? _contactRepository;
		private EfAboutRepository? _aboutRepository;

		public UnitOfWork(SerdehaBlogDbContext context)
        {
            _context = context;
        }

        public ValueTask DisposeAsync()
		{
			return _context.DisposeAsync();
		}

		public IArticleRepository Article => _articleRepository ??= new EfArticleRepository(_context, _context);
		public ICategoryRepository Category => _categoryRepository ??= new EfCategoryRepository(_context);
		public ICommentRepository Comment => _commentRepository ??= new EfCommentRepository(_context);
		public IReplyCommentRepository ReplyComment => _replyCommentRepository ??= new EfReplyCommentRepository(_context);
		public ISocialMediaRepository SocialMedia => _socialMediaRepository ??= new EfSocialMediaRepository(_context);
		public IContactRepository Contact => _contactRepository ??= new EfContactRepository(_context);
		public IAboutRepository About => _aboutRepository ??= new EfAboutRepository(_context);

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
