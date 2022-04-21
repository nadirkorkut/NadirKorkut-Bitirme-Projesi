using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b=>b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.BuildingName).HasMaxLength(50);
            builder.ToTable("Buildings");
        }
    }
}
