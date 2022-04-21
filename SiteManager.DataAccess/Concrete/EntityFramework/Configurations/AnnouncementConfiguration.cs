using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Configurations
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Content).HasColumnType("NVARCHAR(MAX)");
            builder.ToTable("Announcements");
        }
    }
}
