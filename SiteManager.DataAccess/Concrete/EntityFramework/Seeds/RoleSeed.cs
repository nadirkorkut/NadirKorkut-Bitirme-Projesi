using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManager.Domain.Concrete;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Seeds
{
    public class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            string Admin_Role_ID = "fab4fac1-c546-41de-aebc-a14da6895711";
            string User_Role_ID = "b74ddd14 - 6340 - 4840 - 95c2 - db12554843e5";

            builder.HasData(new Role
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = Admin_Role_ID,
                ConcurrencyStamp = Admin_Role_ID
            },
                new Role
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = User_Role_ID,
                    ConcurrencyStamp = User_Role_ID
                });
        }
    }
}
