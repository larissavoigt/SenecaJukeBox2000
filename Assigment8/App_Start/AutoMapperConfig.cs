﻿using System;
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
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithDetail>();

            // Albums
            Mapper.CreateMap<Models.Album, Controllers.AlbumBase>();

#pragma warning restore CS0618
        }
    }
}