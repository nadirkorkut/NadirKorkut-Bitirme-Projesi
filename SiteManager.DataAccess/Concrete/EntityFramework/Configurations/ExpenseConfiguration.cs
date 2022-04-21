using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.ToTable("Expenses");

            builder.HasOne<ExpenseType>(c => c.ExpenseType)
                .WithMany(u => u.Expenses)
                .HasForeignKey(x => x.ExpenseTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Flat>(b => b.Flat)
                .WithMany(u => u.Expenses)
                .HasForeignKey(b => b.FlatId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
