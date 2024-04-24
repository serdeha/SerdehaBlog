using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SerdehaBlog.Entity.Concrete;
using System.Runtime.ConstrainedExecution;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x=>x.NotificationIcon).IsRequired();
            builder.ToTable("Notification");
        }
    }
}
