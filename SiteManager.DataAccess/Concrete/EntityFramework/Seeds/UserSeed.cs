using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManager.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            string Admin_ID = "b74ddd14-6340-4840-95c2-db12554843e5";

            var dbUser = new User()
            {
                Id = Admin_ID,
                Email = "admin@admin.com",
                EmailConfirmed = true,
                NationalityId = "12345678901",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            dbUser.PasswordHash = passwordHasher.HashPassword(dbUser, "Admin*123");

            builder.HasData(dbUser);
        }
    }
}
