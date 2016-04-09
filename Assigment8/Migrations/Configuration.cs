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
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p><strong>Queen</strong> are a British rock band that formed in London in 1970. The classic formation was Freddie Mercury, Brian May, Roger Taylor and John Deacon.</p> <p>The band have released a total of 18 number one albums, 18 number one singles, and 10 number one DVDs. Estimates of their record sales generally range from 150 million to 300 million records, making them one of the world's best-selling music artists. Queen received the Outstanding Contribution to British Music Award from the British Phonographic Industry in 1990. They were inducted into the <strong>Rock and Roll Hall of Fame</strong> in 2001.</p>"
                },

                new Artist
                {
                    Name = "David Bowie",
                    Genre = "Rock",
                    UrlArtist = "http://www.pagesdigital.com/wp-content/uploads/2016/01/1973_drive_aladdin_sane_1000h.jpg",
                    BirthOrStartDate = new System.DateTime(1947, 1, 8),
                    BirthName = "David Robert Jones",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p>David Robert Jones (8 January 1947 – 10 January 2016), known as <strong>David Bowie</strong>, was an English singer, songwriter, actor and record producer. He was a figure in popular music for over five decades, considered by critics and musicians as an innovator, particularly for his work in the 1970s.His career was marked by reinvention and visual presentation, his music and stagecraft significantly influencing popular music.</p><p>During his lifetime, his record sales, estimated at 140 million worldwide, made him one of the world's best-selling music artists. In the UK, he was awarded nine platinum album certifications, eleven gold and eight silver, releasing eleven number-one albums. In the US, he received <strong>five platinum and seven gold certifications</strong>. He was inducted into the <strong>Rock and Roll Hall of Fame</strong> in 1996.</p>"
                },

                new Artist
                {
                    Name = "Daft Punk",
                    Genre = "Electronic",
                    UrlArtist = "http://www.dispatch.com/content/graphics/2013/05/22/2-mus-daft-punk-art-gaqmrm65-12-mus-daft-punk-2-jpg.jpg",
                    BirthOrStartDate = new System.DateTime(1993, 1, 1),
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p><strong>Daft Punk</strong> are an electronic music duo consisting of French musicians <em>Guy-Manuel de Homem-Christo and Thomas Bangalter</em>. The two achieved significant popularity in the late 1990s as part of the French house movement and were met with continued success in the years following, combining elements of <u>house music with funk, techno, disco, rock, and synthpop</u>.</p><p>They are also known for their visual stylization and disguises associated with their music; specifically, the duo have worn ornate<strong> helmets and gloves</strong> to assume <strong>robot personas</strong> in most of their public appearances since 2001. They rarely grant interviews or appear on television.</p>"
                },

                new Artist
                {
                    Name = "Lady Gaga",
                    Genre = "Pop",
                    UrlArtist = "http://popcrush.com/files/2015/09/lady-gaga-emmys-81.jpg?w=600&h=0&zc=1&s=0&a=t&q=89",
                    BirthOrStartDate = new System.DateTime(1986, 3, 28),
                    BirthName = "Stefani Joanne Angelina Germanotta",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p>Stefani Joanne Angelina Germanotta, known professionally as <strong>Lady Gaga</strong>, is an American singer, songwriter, and actress.</p>"
                },

                new Artist
                {
                    Name = "Michael Jackson",
                    Genre = "Pop",
                    UrlArtist = "http://www.keysandchords.com/uploads/3/5/1/8/3518427/2814243_orig.jpg",
                    BirthOrStartDate = new System.DateTime(1958, 8, 29),
                    BirthName = "Michael Joseph Jackson",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p><strong>Michael Joseph Jackson</strong> (August 29, 1958 – June 25, 2009) was an American singer, songwriter, record producer, dancer, and actor.</p> <p>Called the <u>King of Pop</u>, his contributions to <em>music, dance and fashion</em>, along with his publicized personal life, made him a global figure in popular culture for over four decades.<p>"
                },

                new Artist
                {
                    Name = "Dolly Parton",
                    Genre = "Country",
                    UrlArtist = "https://575717b777ff8d928c6b-704c46a8034042e4fc898baf7b3e75d9.ssl.cf1.rackcdn.com/7678298_see-dolly-parton-through-the-years-in-pictures_38739ad3_m.jpg?bg=80725D",
                    BirthOrStartDate = new System.DateTime(1946, 1, 19),
                    BirthName = "Dolly Rebecca Parton Dean",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p><strong>Dolly Rebecca Parton</strong> (born January 19, 1946) is an American singer-songwriter, actress, author, businesswoman, and humanitarian, known primarily for her work in country music.</p> <p>Parton is the <em>most honored female country performer of all time</em>. Achieving 25 RIAA certified gold, platinum, and multi-platinum awards, she has had 25 songs reach No. 1 on the Billboard Country charts, a record for a female artist. She has 41 career top 10 country albums, a record for any artist, and she has 110 career charted singles over the past 40 years. All-inclusive sales of singles, albums, hits collections, and digital downloads during her career have topped 100 million worldwide. She has garnered eight Grammy Awards, two Academy Award nominations, ten Country Music Association Awards, seven Academy of Country Music Awards, three American Music Awards, and is one of only seven female artists to win the Country Music Association's Entertainer of the Year Award. Parton has received 46 Grammy nominations, tying her with Bruce Springsteen for the most Grammy nominations and placing her in tenth place overall.</p>"
                },

                new Artist
                {
                    Name = "Tchaikovsky",
                    Genre = "Classical",
                    UrlArtist = "http://www.swarthmore.edu/sites/default/files/styles/slideshow_large/public/assets/images/russian/Russian_Slideshow_Tchaikovsky.jpg?itok=le3Y4ieV",
                    BirthOrStartDate = new System.DateTime(1840, 5, 7),
                    BirthName = "Pyotr Ilyich Tchaikovsky",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p><strong>Pyotr Ilyich Tchaikovsky</strong> was a Russian composer of the <u>late-Romantic period</u>, some of whose works are among the most popular music in the classical repertoire. He was the first Russian composer whose music made a lasting impression internationally, bolstered by his appearances as a guest conductor in Europe and the United States. Tchaikovsky was honored in 1884, by Emperor Alexander III, and awarded a lifetime pension.</p>"
                },

                new Artist
                {
                    Name = "Madonna",
                    Genre = "Pop",
                    UrlArtist = "http://www1.pictures.zimbio.com/mp/AOvR5SbWDJbl.jpg",
                    BirthOrStartDate = new System.DateTime(1958, 8, 16),
                    BirthName = "Madonna Louise Ciccone",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p><strong>Madonna Louise Ciccone</strong> is an American singer, songwriter, actress, and businesswoman.</p>"
                },

                new Artist
                {
                    Name = "Celine Dion",
                    Genre = "R&B",
                    UrlArtist = "http://www.radioandmusic.com/sites/www.radioandmusic.com/files/images/entertainment/2016/01/21/Celine-Dion3.jpg",
                    BirthOrStartDate = new System.DateTime(1968, 3, 30),
                    BirthName = "Celine Marie Claudette Dion",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p><strong>Céline Marie Claudette Dion</strong>, born 30 March 1968, is a <em>Canadian singer and businesswoman</em>.</p> <p>While her releases have often received mixed critical reception, she is regarded as one of pop music's most influential voices. Dion has won <u>five Grammy Awards</u>, including <u>Album of the Year and Record of the Year</u>. She is the second best-selling female artist in the US during the Nielsen SoundScan era.</p>"
                },

                new Artist
                {
                    Name = "Drake",
                    Genre = "Hip Hop",
                    UrlArtist = "http://www.mtv.com/news/photos/d/drake_complex_100125/01_drake.jpg",
                    BirthOrStartDate = new System.DateTime(1986, 10, 24),
                    BirthName = "Aubrey Drake Graham",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p>Aubrey Drake Graham, born October 24, 1986) and better known as Drake, is a <em>Canadian rapper, singer, songwriter, record producer and actor</em>, born and raised in <strong>Toronto, Ontario</strong>. He first garnered recognition for his role as Jimmy Brooks on the television series Degrassi: The Next Generation. He later rose to prominence as a rapper, releasing several mixtapes before signing to Lil Wayne's Young Money Entertainment in June 2009.</p>"
                },

                new Artist
                {
                    Name = "Rihanna",
                    Genre = "Pop",
                    UrlArtist = "https://kiss100.co.ke/wp-content/uploads/2015/03/Rihanna-1.jpg",
                    BirthOrStartDate = new System.DateTime(1988, 2, 20),
                    BirthName = "Robyn Rihanna Fenty",
                    Executive = "executive@senecajukebox.com",
                    Profile = "<p>With sales exceeding 200 million records worldwide, Rihanna is one of the best-selling artists of all time.</p> <p>Rihanna is the youngest and fastest solo artist to earn fourteen number-one singles on the Billboard Hot 100, and was named the Digital Songs Artist of the 2000s decade and the top Hot 100 artist of the 2010s decade by Billboard. Among numerous awards and accolades, Rihanna has won eight Grammy Awards; eight American Music Awards; 23 Billboard Music Awards; two BRIT Awards; and was awarded the inaugural Icon Award at the American Music Awards of 2013. Widely recognized for frequently reinventing her style and image, she received the Fashion Icon lifetime achievement award from the Council of Fashion Designers of America in 2014. Forbes ranked Rihanna the fourth most powerful celebrity of 2012, and was named one of Time's 100 Most Influential People in the World later that year.</p>"
                },

            };

            artists.ForEach(a => context.Artists.AddOrUpdate(r => r.Name, a));

            var albums = new List<Album> {
                new Album
                {
                    Name = "The Fame",
                    Genre = "Pop",
                    UrlAlbum = "http://www.ladygaga.com/sites/g/files/g20001281/f/styles/300x300/public/201306/00602517891388.jpg?itok=S3SusKRe",
                    ReleaseDate = new System.DateTime(2008, 8, 19)
                },

                new Album
                {
                    Name = "Hot Space",
                    Genre = "Rock",
                    UrlAlbum = "https://upload.wikimedia.org/wikipedia/en/3/3c/Queen_Hot_Space.png",
                    ReleaseDate = new System.DateTime(1982, 5, 21)
                },

                new Album
                {
                    Name = "Falling into You",
                    Genre = "Pop",
                    UrlAlbum = "https://ukutabs.com/uploads/2012/09/Falling-Into-You.jpg",
                    ReleaseDate = new System.DateTime(1996, 3, 8)
                },

                new Album
                {
                    Name = "Let's Talk About Love",
                    Genre = "Pop",
                    UrlAlbum = "https://ukutabs.com/uploads/2013/05/Lets-Talk-About-Love.jpg",
                    ReleaseDate = new System.DateTime(1997, 11, 14)
                },

                new Album
                {
                    Name = "Pin Ups",
                    Genre = "Rock",
                    UrlAlbum = "https://upload.wikimedia.org/wikipedia/en/b/be/PinUps.jpg",
                    ReleaseDate = new System.DateTime(1973, 10, 19)
                },

                new Album
                {
                    Name = "What's My Name?",
                    Genre = "R&B",
                    UrlAlbum = "http://music-video-buzz.com/wp-content/uploads/2011/03/rihanna-whats_my_name-feat-drake-fanmade1-500x500-300x300.png",
                    ReleaseDate = new System.DateTime(2010, 10, 26)
                },

            };

            albums.ForEach(a => a.Coordinator = coordinators[rnd.Next(coordinators.Count)]); // add random coordinator
            albums.ForEach(a => context.Albums.AddOrUpdate(r => r.Name, a));

            var tracks = new List<Track> {
                new Track
                {
                    Name = "Hello",
                    Genre = "Pop",
                    Composers = "Adele Adkins, Greg Kurstin"
                },

                new Track
                {
                    Name = "What's My Name?",
                    Genre = "Hip Hop",
                    Composers = "Mikkel S. Eriksen, Tor Erik Hermansen"
                },

                new Track
                {
                    Name = "Bohemian Rhapsody",
                    Genre = "Rock",
                    Composers = "Freddie Mercury"
                },

                new Track
                {
                    Name = "Under Pressure",
                    Genre = "Rock",
                    Composers = "Queen, David Bowie"
                },

                new Track
                {
                    Name = "Heroes",
                    Genre = "Rock",
                    Composers = "David Bowie, Brian Eno"
                },

                new Track
                {
                    Name = "It's All Coming Back To Me Now",
                    Genre = "Pop",
                    Composers = "Jim Steinman"
                },

                new Track
                {
                    Name = "Because You Loved Me",
                    Genre = "Pop",
                    Composers = "Diane Warren"
                },

                new Track
                {
                    Name = "The Reason",
                    Genre = "Pop",
                    Composers = "Carole King, Mark Hudson"
                },

                new Track
                {
                    Name = "Immortality",
                    Genre = "Pop",
                    Composers = "Barry Gibb, Robin Gibb"
                },

                new Track
                {
                    Name = "My Heart Will Go On",
                    Genre = "Pop",
                    Composers = "James Horner, Will Jennings"
                },

                new Track
                {
                    Name = "Sorrow",
                    Genre = "Rock",
                    Composers = "Bob Feldman, Jerry Goldstein"
                },

                new Track
                {
                    Name = "Just Dance",
                    Genre = "Pop",
                    Composers = "Lady Gaga, Nadir RedOne"
                },

            };

            tracks.ForEach(t => t.Clerk = clerks[rnd.Next(clerks.Count)]); // add random clerk
            tracks.ForEach(t => context.Tracks.AddOrUpdate(r => r.Name, t));

            context.SaveChanges();

            // Artists - Albums association
            AddOrUpdateArtistAlbums(context, "Lady Gaga", "The Fame");
            AddOrUpdateArtistAlbums(context, "Queen", "Hot Space");
            AddOrUpdateArtistAlbums(context, "David Bowie", "Hot Space");
            AddOrUpdateArtistAlbums(context, "Celine Dion", "Falling into You");
            AddOrUpdateArtistAlbums(context, "Celine Dion", "Let's Talk About Love");
            AddOrUpdateArtistAlbums(context, "David Bowie", "Pin Ups");
            AddOrUpdateArtistAlbums(context, "Rihanna", "What's My Name?");
            AddOrUpdateArtistAlbums(context, "Drake", "What's My Name?");

            //Albums - Tracks association
            AddOrUpdateAlbumTracks(context, "What's My Name?", "What's My Name?");
            AddOrUpdateAlbumTracks(context, "Hot Space", "Under Pressure");
            AddOrUpdateAlbumTracks(context, "Falling into You", "It's All Coming Back To Me Now");
            AddOrUpdateAlbumTracks(context, "Falling into You", "Because You Loved Me");
            AddOrUpdateAlbumTracks(context, "Let's Talk About Love", "The Reason");
            AddOrUpdateAlbumTracks(context, "Let's Talk About Love", "Immortality");
            AddOrUpdateAlbumTracks(context, "Let's Talk About Love", "My Heart Will Go On");
            AddOrUpdateAlbumTracks(context, "Pin Ups", "Sorrow");
            AddOrUpdateAlbumTracks(context, "The Fame", "Just Dance");
        }

        void AddOrUpdateArtistAlbums(Assigment8.Models.ApplicationDbContext context, string artistName, string albumName)
        {
            var artist = context.Artists.SingleOrDefault(a => a.Name == artistName);
            var album = artist.Albums.SingleOrDefault(a => a.Name == albumName);
            if (album == null)
            {
                artist.Albums.Add(context.Albums.Single(a => a.Name == albumName));
            }

        }

        void AddOrUpdateAlbumTracks(Assigment8.Models.ApplicationDbContext context, string albumName, string trackName)
        {
            var album = context.Albums.SingleOrDefault(a => a.Name == albumName);
            var track = album.Tracks.SingleOrDefault(t => t.Name == trackName);
            if (track == null)
            {
                album.Tracks.Add(context.Tracks.Single(t => t.Name == trackName));
            }

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
