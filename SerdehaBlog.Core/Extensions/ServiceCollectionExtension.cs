using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SerdehaBlog.Business.Absract;
using SerdehaBlog.Business.Concrete;
using SerdehaBlog.Core.Helpers.Abstract;
using SerdehaBlog.Core.Helpers.Concrete;
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
            serviceCollection.AddScoped<ISocialMediaRepository, EfSocialMediaRepository>();
            serviceCollection.AddScoped<ISocialMediaService, SocialMediaManager>();
			serviceCollection.AddScoped<IContactRepository, EfContactRepository>();
			serviceCollection.AddScoped<IContactService, ContactManager>();
            serviceCollection.AddScoped<IAboutRepository, EfAboutRepository>();
            serviceCollection.AddScoped<IAboutService, AboutManager>();

            return serviceCollection;
        }

		public static void ConfigureWritable<T>(this IServiceCollection services, IConfigurationSection section, string file = "appsettings.json") where T : class, new()
		{
			services.Configure<T>(section);
			services.AddTransient<IWritableOptions<T>>(provider =>
			{
				var environment = provider.GetService<IHostEnvironment>();
				var options = provider.GetService<IOptionsMonitor<T>>();

				return new WritableOptions<T>(environment!, options!, section.Key, file);
			});
		}
	}
}
