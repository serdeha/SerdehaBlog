using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(70);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.ToTable("Categories");
            builder.HasMany(x => x.Articles).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Categories).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasData(new Category
            {
                Id = 1,
                ModifiedByName = "InitialCreate",
                CreatedByName = "Serdeha",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Name = "Teknoloji",
                Note = "Teknoloji postlarının paylaşıldığı kategori",
                AppUserId = 1
            },
            new Category
            {
                Id = 2,
                ModifiedByName = "InitialCreate",
                CreatedByName = "Serdeha",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Name = "Yazılım",
                Note = "Yazılım postlarının paylaşıldığı kategori",
                AppUserId = 1
            });
        }
    }
}
