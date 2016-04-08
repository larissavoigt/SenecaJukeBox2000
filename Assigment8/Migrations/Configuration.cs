namespace Assigment8.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assigment8.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assigment8.Models.ApplicationDbContext context)
        {
            context.RoleClaims.AddOrUpdate(
                r => r.Name,
                new Models.RoleClaim { Name = "Executive" },
                new Models.RoleClaim { Name = "Coordinador" },
                new Models.RoleClaim { Name = "Clerk" },
                new Models.RoleClaim { Name = "Staff" },
                new Models.RoleClaim { Name = "Intern" },
                new Models.RoleClaim { Name = "Viewer" }
            );

            AddOrUpdateUser(context, "executive@senecajukebox.com", new List<string> { "Executive", "Coordinator", "Clerk", "Staff" });
            AddOrUpdateUser(context, "coordinator@senecajukebox.com", new List<string> { "Coordinator", "Clerk", "Staff" });
            AddOrUpdateUser(context, "clerk@senecajukebox.com", new List<string> { "Clerk", "Staff" });
            AddOrUpdateUser(context, "staff@senecajukebox.com", new List<string> { "Staff" });
        }

        void AddOrUpdateUser(Assigment8.Models.ApplicationDbContext context, string email, List<string> roles)
        {
            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    manager.Create(new IdentityRole { Name = role });
                }
            }

            if (!context.Users.Any(u => u.UserName == email))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = email };

                manager.Create(user, "Passw0rd!");

                foreach (var role in roles)
                {
                    manager.AddToRole(user.Id, role);
                }

            }
        }
    }
}
