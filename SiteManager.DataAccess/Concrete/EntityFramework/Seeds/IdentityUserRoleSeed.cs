using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Seeds
{
    public class IdentityUserRoleSeed : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            string Admin_ID = "b74ddd14-6340-4840-95c2-db12554843e5";
            string Admin_Role_ID = "fab4fac1-c546-41de-aebc-a14da6895711";

            builder.HasData(new IdentityUserRole<string>
            {
                UserId = Admin_ID,
                RoleId = Admin_Role_ID,
            });
        }
    }
}
