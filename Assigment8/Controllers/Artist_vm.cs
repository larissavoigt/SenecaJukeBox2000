using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assigment8.Controllers
{
    public class ArtistBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Birth Name")]
        public string BirthName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Birth or Start Date")]
        public DateTime BirthOrStartDate { get; set; }

        [Required, StringLength(150)]
        public string Executive { get; set; }

        [Required]
        [Display(Name = "Primary Genre")]
        public string Genre { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Name or Stage Name")]
        public string Name { get; set; }

        [Required, StringLength(150)]
        [DataType(DataType.Url)]
        [Display(Name = "Artist Photo")]
        public string UrlArtist { get; set; }
    }

    public class ArtistAdd : ArtistBase
    {

    }

    public class ArtistAddForm : ArtistBase
    {
        public SelectList GenreList { get; set; }
    }

    public class ArtistWithDetail : ArtistBase
    {
        public ArtistWithDetail()
        {
            Albums = new List<AlbumBase>();
        }

        [Display(Name = "List of Albums")]
        public ICollection<AlbumBase> Albums { get; set; }
    }
}