namespace Assigment8.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assigment8.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assigment8.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.RoleClaims.AddOrUpdate(
                r => r.Name,
                new Models.RoleClaim { Name = "Executive" },
                new Models.RoleClaim { Name = "Coordinador" },
                new Models.RoleClaim { Name = "Clerk" },
                new Models.RoleClaim { Name = "Staff" },
                new Models.RoleClaim { Name = "Intern" },
                new Models.RoleClaim { Name = "Viewer" }
            );
        }
    }
}
