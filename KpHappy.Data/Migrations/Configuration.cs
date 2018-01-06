namespace KpHappy.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KpHappy.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<KpHappy.Data.KpHappyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KpHappy.Data.KpHappyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<KpApplicationUser>(new UserStore<KpApplicationUser>(new KpHappyDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new KpHappyDbContext()));

            var user = new KpApplicationUser()
            {
                UserName = "phamkhanh",
                Email = "phamkhanh1811@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Kp Happy Tech"

            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("phamkhanh1811@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
