using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Data.Concrete.EntityFramework.Configurations
{
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.HasKey(a => a.Id);
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x=>x.Name).HasMaxLength(100);
			builder.Property(x=>x.Email).HasMaxLength(300);
			builder.Property(x=>x.Email).IsRequired();
			builder.Property(x=>x.Subject).HasMaxLength(300);
			builder.Property(x=>x.Subject).IsRequired();
			builder.Property(x=>x.Text).IsRequired();
			builder.Property(x=>x.Text).HasMaxLength(500);
			builder.ToTable("Contact");
		}
	}
}
