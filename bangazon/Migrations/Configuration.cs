namespace bangazon.Migrations
{
    using bangazon.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<bangazon.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bangazon.Models.ApplicationDbContext context)
        {
            var adminRole = new IdentityRole("Admin");
            context.Roles.AddOrUpdate(r => r.Name, adminRole);

            context.SaveChanges();

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                UserName = "marcus",
                Email = "marcus@gmail.com",
            };

            userManager.CreateAsync(user, "password").Wait();

            var addedUser = context.Users.First(x => x.UserName == user.UserName);

            userManager.AddToRoleAsync(addedUser.Id, "Admin").Wait();
        }
    }
}
