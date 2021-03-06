using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteManager.Domain.Concrete;
using System.Reflection;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Contexts
{
    public class SiteManagerDbContext : IdentityDbContext<User,Role,string>
    {
        public SiteManagerDbContext(DbContextOptions<SiteManagerDbContext> options):base(options)
        {

        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
