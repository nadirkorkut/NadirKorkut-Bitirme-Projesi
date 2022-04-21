using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.MessageText).HasColumnType("NVARCHAR");
            builder.Property(x => x.MessageText).HasMaxLength(500);
        }
    }
}
