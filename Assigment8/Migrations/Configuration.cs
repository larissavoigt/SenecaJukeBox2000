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
            Random rnd = new Random();

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

            var coordinators = new List<string> { "executive@senecajukebox.com", "coordinator@senecajukebox.com" };
            var clerks = new List<string> { "executive@senecajukebox.com", "coordinator@senecajukebox.com", "clerk@senecajukebox.com" };

            var genres = new List<string> {
                "Alternative",
                "Blues",
                "Classical",
                "Country",
                "Dance",
                "Easy Listening",
                "Electronic",
                "Hip Hop / Rap",
                "Indie Pop",
                "Jazz",
                "New Age",
                "Opera",
                "Pop",
                "R&B / Soul",
                "Reggae",
                "Rock",
                "World Music / Beats"
            };

            genres.ForEach(g => context.Genres.AddOrUpdate(r => r.Name, new Genre { Name = g }));

            var artists = new List<Artist>
            {
                new Artist
                {
                    Name = "Queen",
                    Genre = "Rock",
                    UrlArtist = "http://www.stereoboard.com/images/stories/new/600x400xqueen_eb_121211.jpg.pagespeed.ic.ETqLIKAawN.jpg",
                    BirthOrStartDate = new System.DateTime(1970, 1, 1),
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "David Bowie",
                    Genre = "Rock",
                    UrlArtist = "http://www.pagesdigital.com/wp-content/uploads/2016/01/1973_drive_aladdin_sane_1000h.jpg",
                    BirthOrStartDate = new System.DateTime(1947, 1, 8),
                    BirthName = "David Robert Jones",
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Daft Punk",
                    Genre = "Electronic",
                    UrlArtist = "http://www.dispatch.com/content/graphics/2013/05/22/2-mus-daft-punk-art-gaqmrm65-12-mus-daft-punk-2-jpg.jpg",
                    BirthOrStartDate = new System.DateTime(1993, 1, 1),
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Lady Gaga",
                    Genre = "Pop",
                    UrlArtist = "http://popcrush.com/files/2015/09/lady-gaga-emmys-81.jpg?w=600&h=0&zc=1&s=0&a=t&q=89",
                    BirthOrStartDate = new System.DateTime(1986, 3, 28),
                    BirthName = "Stefani Joanne Angelina Germanotta",
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Michael Jackson",
                    Genre = "Pop",
                    UrlArtist = "http://www.keysandchords.com/uploads/3/5/1/8/3518427/2814243_orig.jpg",
                    BirthOrStartDate = new System.DateTime(1958, 8, 29),
                    BirthName = "Michael Joseph Jackson",
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Dolly Parton",
                    Genre = "Country",
                    UrlArtist = "https://575717b777ff8d928c6b-704c46a8034042e4fc898baf7b3e75d9.ssl.cf1.rackcdn.com/7678298_see-dolly-parton-through-the-years-in-pictures_38739ad3_m.jpg?bg=80725D",
                    BirthOrStartDate = new System.DateTime(1946, 1, 19),
                    BirthName = "Dolly Rebecca Parton Dean",
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Tchaikovsky",
                    Genre = "Classical",
                    UrlArtist = "http://www.swarthmore.edu/sites/default/files/styles/slideshow_large/public/assets/images/russian/Russian_Slideshow_Tchaikovsky.jpg?itok=le3Y4ieV",
                    BirthOrStartDate = new System.DateTime(1840, 5, 7),
                    BirthName = "Pyotr Ilyich Tchaikovsky",
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Madonna",
                    Genre = "Pop",
                    UrlArtist = "http://www1.pictures.zimbio.com/mp/AOvR5SbWDJbl.jpg",
                    BirthOrStartDate = new System.DateTime(1958, 8, 16),
                    BirthName = "Madonna Louise Ciccone",
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Celine Dion",
                    Genre = "R&B",
                    UrlArtist = "http://www.radioandmusic.com/sites/www.radioandmusic.com/files/images/entertainment/2016/01/21/Celine-Dion3.jpg",
                    BirthOrStartDate = new System.DateTime(1968, 3, 30),
                    BirthName = "Celine Marie Claudette Dion",
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Drake",
                    Genre = "Hip Hop",
                    UrlArtist = "http://www.mtv.com/news/photos/d/drake_complex_100125/01_drake.jpg",
                    BirthOrStartDate = new System.DateTime(1986, 10, 24),
                    BirthName = "Aubrey Drake Graham",
                    Executive = "executive@senecajukebox.com"
                },

                new Artist
                {
                    Name = "Rihanna",
                    Genre = "Pop",
                    UrlArtist = "https://kiss100.co.ke/wp-content/uploads/2015/03/Rihanna-1.jpg",
                    BirthOrStartDate = new System.DateTime(1988, 2, 20),
                    BirthName = "Robyn Rihanna Fenty",
                    Executive = "executive@senecajukebox.com"
                },

            };

            artists.ForEach(a => context.Artists.AddOrUpdate(r => r.Name, a));
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
