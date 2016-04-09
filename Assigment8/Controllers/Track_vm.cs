using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assigment8.Controllers
{

    public class TrackBase 
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(150)]
        public string Clerk { get; set; }

        [StringLength(150)]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }

        public IEnumerable<int> AlbumIds { get; set; }
    }

    public class TrackAdd : TrackBase
    {
        public HttpPostedFileBase ClipUpload { get; set; }
    }

    public class TrackAddForm : TrackBase
    {
        public SelectList GenreList { get; set; }

        [Required]
        [Display(Name = "Clip Upload")]
        [DataType(DataType.Upload)]
        public string ClipUpload { get; set; }
    }

    public class TrackWithDetail : TrackBase
    {
        public TrackWithDetail()
        {
            Albums = new List<AlbumBase>();
        }

        [Display(Name = "Album")]
        public ICollection<AlbumBase> Albums { get; set; }

        public string AlbumName()
        {
            var album = this.Albums.FirstOrDefault();
            if (album == null)
            {
                return "-";
            }
            return album.Name;
        }

        [Display(Name = "Clip")]
        public string ClipUrl
        {
            get
            {
                return $"/clip/{Id}";
            }
        }
    }

    public class TrackClip
    {
        public int Id { get; set; }
        public string ClipContentType { get; set; }
        public byte[] Clip { get; set; }
    }
}