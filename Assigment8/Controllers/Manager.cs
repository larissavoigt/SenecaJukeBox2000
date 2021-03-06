﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assigment8.Models;
using System.Security.Claims;

namespace Assigment8.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // Declare a property to hold the user account for the current request
        // Can use this property here in the Manager class to control logic and flow
        // Can also use this property in a controller 
        // Can also use this property in a view; for best results, 
        // near the top of the view, add this statement:
        // var userAccount = new ConditionalMenu.Controllers.UserAccount(User as System.Security.Claims.ClaimsPrincipal);
        // Then, you can use "userAccount" anywhere in the view to render content
        public UserAccount UserAccount { get; private set; }

        public Manager()
        {
            // If necessary, add constructor code here

            // Initialize the UserAccount property
            UserAccount = new UserAccount(HttpContext.Current.User as ClaimsPrincipal);

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()

        public IEnumerable<string> RoleClaimGetAllStrings()
        {
            return ds.RoleClaims.Select(r => (string)r.Name).ToList();
        }

        public IEnumerable<ArtistWithDetail> ArtistGetAllWithDetail()
        {
            return Mapper.Map<IEnumerable<ArtistWithDetail>>
                (ds.Artists.Include("Albums").OrderBy(a => a.Name));
        }

        public ArtistBase ArtistGetById(int? id)
        {
            var o = ds.Artists.Find(id);
            return (o == null) ? null : Mapper.Map<ArtistBase>(o);
        }

        public ArtistWithDetail ArtistGetByIdWithDetail(int id)
        {
            var o = ds.Artists.Include("Albums").Include("MediaItems").SingleOrDefault(e => e.Id == id);
            return (o == null) ? null : Mapper.Map<ArtistWithDetail>(o);
        }

        public ArtistBase ArtistAdd(ArtistAdd newItem)
        {
            var addedItem = ds.Artists.Add(Mapper.Map<Artist>(newItem));
            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<ArtistBase>(addedItem);
        }

        public ArtistWithDetail ArtistMediaItemAdd(MediaItemAdd newItem)
        {
            // Validate the associated item
            var a = ds.Artists.Find(newItem.ArtistId);

            if (a == null)
            {
                return null;
            }
            else
            {
                // Attempt to add the new item
                var addedItem = new MediaItem();
                ds.MediaItems.Add(addedItem);

                addedItem.Caption = newItem.Caption;
                addedItem.Artist = a;

                // Handle the uploaded media item...

                // First, extract the bytes from the HttpPostedFile object
                byte[] mediaItemBytes = new byte[newItem.MediaUpload.ContentLength];
                newItem.MediaUpload.InputStream.Read(mediaItemBytes, 0, newItem.MediaUpload.ContentLength);

                // Then, configure the new object's properties
                addedItem.Content = mediaItemBytes;
                addedItem.ContentType = newItem.MediaUpload.ContentType;

                ds.SaveChanges();

                return (addedItem == null) ? null : Mapper.Map<ArtistWithDetail>(a);
            }
        }

        public AlbumBase AlbumGetById(int? id)
        {
            var o = ds.Albums.Find(id);
            return (o == null) ? null : Mapper.Map<AlbumBase>(o);
        }

        public IEnumerable<AlbumWithDetail> AlbumGetAllWithDetail()
        {
            return Mapper.Map<IEnumerable<AlbumWithDetail>>
                (ds.Albums.Include("Artists").Include("Tracks").OrderBy(a => a.Name));
        }

        public AlbumWithDetail AlbumGetByIdWithDetail(int id)
        {
            var o = ds.Albums.Include("Artists").Include("Tracks").SingleOrDefault(a => a.Id == id);
            return (o == null) ? null : Mapper.Map<AlbumWithDetail>(o);
        }

        // Create a new album with artists
        public AlbumWithDetail AlbumAdd(AlbumAdd newItem)
        {

            var o = ds.Albums.Add(Mapper.Map<Album>(newItem));

            foreach (var item in newItem.ArtistIds)
            {
                var a = ds.Artists.Find(item);
                o.Artists.Add(a);
            }

            foreach (var item in newItem.TrackIds)
            {
                var a = ds.Tracks.Find(item);
                o.Tracks.Add(a);
            }

            ds.SaveChanges();

            return (o == null) ? null : Mapper.Map<AlbumWithDetail>(o);
        }

        public IEnumerable<GenreBase> GenreGetAll()
        {
            return Mapper.Map<IEnumerable<GenreBase>>(ds.Genres.OrderBy(a => a.Name));
        }

        public IEnumerable<TrackBase> TrackGetAll()
        {
            return Mapper.Map<IEnumerable<TrackBase>>(ds.Tracks.OrderBy(a => a.Name));
        }

        public TrackBase TrackGetById(int? id)
        {
            var o = ds.Tracks.Find(id);
            return (o == null) ? null : Mapper.Map<TrackBase>(o);
        }

        public TrackClip TrackClipGetById(int id)
        {
            var o = ds.Tracks.Find(id);

            return (o == null) ? null : Mapper.Map<TrackClip>(o);
        }

        public TrackBase TrackAdd(TrackAdd newItem)
        {
            var o = ds.Tracks.Add(Mapper.Map<Track>(newItem));

            foreach (var item in newItem.AlbumIds)
            {
                var a = ds.Albums.Find(item);
                o.Albums.Add(a);
            }

            // Handle the uploaded audio...

            // First, extract the bytes from the HttpPostedFile object
            byte[] clipBytes = new byte[newItem.ClipUpload.ContentLength];
            newItem.ClipUpload.InputStream.Read(clipBytes, 0, newItem.ClipUpload.ContentLength);

            o.Clip = clipBytes;
            o.ClipContentType = newItem.ClipUpload.ContentType;

            ds.SaveChanges();

            return (o == null) ? null : Mapper.Map<TrackWithDetail>(o);
        }

        public IEnumerable<TrackWithDetail> TrackGetAllWithDetail()
        {
            return Mapper.Map<IEnumerable<TrackWithDetail>>
                (ds.Tracks.Include("Albums").OrderBy(a => a.Name));
        }

        public TrackWithDetail TrackGetByIdWithDetail(int id)
        {
            var o = ds.Tracks.Include("Albums").SingleOrDefault(e => e.Id == id);
            return (o == null) ? null : Mapper.Map<TrackWithDetail>(o);
        }

        public MediaItemContent ArtistMediaItemGetById(string stringId)
        {
            var o = ds.MediaItems.SingleOrDefault(p => p.StringId == stringId);

            return (o == null) ? null : Mapper.Map<MediaItemContent>(o);
        }

    }

    // New "UserAccount" class for the authenticated user
    // Includes many convenient members to make it easier to render user account info
    // Study the properties and methods, and think about how you could use it
    public class UserAccount
    {
        // Constructor, pass in the security principal
        public UserAccount(ClaimsPrincipal user)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                Principal = user;

                // Extract the role claims
                RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                // User name
                Name = user.Identity.Name;

                // Extract the given name(s); if null or empty, then set an initial value
                string gn = user.Claims.Where(c => c.Type == ClaimTypes.GivenName).Select(c =>c.Value).SingleOrDefault();
                if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                GivenName = gn;

                // Extract the surname; if null or empty, then set an initial value
                string sn = user.Claims.Where(c => c.Type == ClaimTypes.Surname).Select(c =>c.Value).SingleOrDefault();
                if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                Surname = sn;

                IsAuthenticated = true;
                IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
            }
            else
            {
                RoleClaims = new List<string>();
                Name = "anonymous";
                GivenName = "Unauthenticated";
                Surname = "Anonymous";
                IsAuthenticated = false;
                IsAdmin = false;
            }

            NamesFirstLast = $"{GivenName} {Surname}";
            NamesLastFirst = $"{Surname}, {GivenName}";
        }

        // Public properties
        public ClaimsPrincipal Principal { get; private set; }
        public IEnumerable<string> RoleClaims { get; private set; }

        public string Name { get; set; }

        public string GivenName { get; private set; }
        public string Surname { get; private set; }

        public string NamesFirstLast { get; private set; }
        public string NamesLastFirst { get; private set; }

        public bool IsAuthenticated { get; private set; }

        // Add other role-checking properties here as needed
        public bool IsAdmin { get; private set; }

        public bool HasRoleClaim(string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
        }

        public bool HasClaim(string type, string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(type, value) ? true : false;
        }
    }

}