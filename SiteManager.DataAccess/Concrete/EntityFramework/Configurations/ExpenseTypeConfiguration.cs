using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Configurations
{
    public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TypeName).HasMaxLength(50);
            builder.ToTable("ExpenseTypes");
        }
    }
}
