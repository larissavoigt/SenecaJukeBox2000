using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assigment8
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();

            // Disable AutoMapper v4.2.x warnings
#pragma warning disable CS0618

            // AutoMapper create map statements

            Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();

            // Artists 
            Mapper.CreateMap<Models.Artist, Controllers.ArtistBase>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithDetail>();
            Mapper.CreateMap<Controllers.ArtistAdd, Models.Artist>();
            Mapper.CreateMap<Controllers.ArtistAddForm, Models.Artist>();

            // Albums
            Mapper.CreateMap<Models.Album, Controllers.AlbumBase>();
            Mapper.CreateMap<Models.Album, Controllers.AlbumWithDetail>();
            Mapper.CreateMap<Controllers.AlbumAdd, Models.Album>();
            Mapper.CreateMap<Controllers.AlbumBase, Controllers.AlbumAddForm>();

            // Genres
            Mapper.CreateMap<Models.Genre, Controllers.GenreBase>();

            // Tracks
            Mapper.CreateMap<Models.Track, Controllers.TrackBase>();
            Mapper.CreateMap<Controllers.TrackAdd, Models.Track>();
            Mapper.CreateMap<Controllers.TrackAddForm, Models.Track>();
            Mapper.CreateMap<Models.Track, Controllers.TrackWithDetail>();

#pragma warning restore CS0618
        }
    }
}