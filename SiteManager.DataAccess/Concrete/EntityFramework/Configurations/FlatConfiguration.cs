using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManager.Domain.Concrete;
using System;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Configurations
{
    public class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.ToTable("Flats");

            builder.HasOne<Building>(b => b.Building)
                .WithMany(f => f.Flats)
                .HasForeignKey(b => b.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<User>(b => b.User)
                .WithMany(f => f.Flats)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
