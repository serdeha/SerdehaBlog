using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SerdehaBlog.Data.Concrete.EntityFramework.Configurations;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Contexts
{
    public class SerdehaBlogDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public SerdehaBlogDbContext(DbContextOptions<SerdehaBlogDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReplyComment> ReplyComments { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ArticleConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new ReplyCommentConfiguration());
            builder.ApplyConfiguration(new SocialMediaConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new AboutConfiguration());
            builder.ApplyConfiguration(new NotificationConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
