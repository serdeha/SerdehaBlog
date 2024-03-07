using Microsoft.Extensions.DependencyInjection;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Business.Concrete;
using SerdehaBlog.Data.Absract;
using SerdehaBlog.Data.Concrete.EntityFramework.Repositories;
using SerdehaBlog.Data.UnitOfWork;

namespace SerdehaBlog.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IArticleRepository, EfArticleRepository>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<ICategoryRepository, EfCategoryRepository>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<ICommentRepository, EfCommentRepository>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();
            serviceCollection.AddScoped<IReplyCommentRepository, EfReplyCommentRepository>();
            serviceCollection.AddScoped<IReplyCommentService, ReplyCommentManager>();            

            return serviceCollection;
        }
    }
}
