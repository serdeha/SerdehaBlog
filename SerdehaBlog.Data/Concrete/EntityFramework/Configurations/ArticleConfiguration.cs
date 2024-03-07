using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(300);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(200);
            builder.Property(a => a.SeoDescription).HasMaxLength(350);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.ViewCount).IsRequired();
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Articles).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.Comments).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId);
            builder.ToTable("Articles");
            builder.HasData(new Article
            {
                Id = 1,
                ModifiedDate = DateTime.Now,
                Note = "InitialCreate",
                CategoryId = 1,
                Content =
                    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedByName = "InitialCreate",
                SeoAuthor = "Serdeha",
                SeoDescription = "Lorem Makalesi hakkında detaylar",
                SeoTags = "lorem, ipsum, sit, ameth, kamare, camaro, lagaluga",
                ThumbnailPath = "1.png",
                Title = "Lorem Ipsum Hakkında Detaylı Bilgiler",
                AppUserId = 1,
                ViewCount = 100
            },
            new Article
            {
                Id = 2,
                ModifiedDate = DateTime.Now,
                Note = "InitialCreate",
                CategoryId = 2,
                Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, ",
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedByName = "InitialCreate",
                SeoAuthor = "Serdeha",
                SeoDescription = "Its Long Day Makalesi hakkında detaylar",
                SeoTags = "lorem, ipsum, sit, ameth, kamare, camaro, lagaluga",
                ThumbnailPath = "1.png",
                Title = "Its Long Day Hakkında Detaylı Bilgiler",
                AppUserId = 1,
                ViewCount = 0
            });
        }
    }
}
