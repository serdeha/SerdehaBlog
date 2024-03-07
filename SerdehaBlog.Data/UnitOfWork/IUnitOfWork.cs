using SerdehaBlog.Data.Absract;

namespace SerdehaBlog.Data.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Article { get; }
        ICategoryRepository Category { get; }
        ICommentRepository Comment { get; }
        IReplyCommentRepository ReplyComment { get; }
        Task<int> SaveChangesAsync();
        void SaveChanges();
    }
}
