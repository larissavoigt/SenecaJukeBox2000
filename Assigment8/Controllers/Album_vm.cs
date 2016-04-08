using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assigment8.Controllers
{
    public class AlbumBase
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Coordinator")]
        public string Coordinator { get; set; }

        [Required]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Album Cover")]
        public string UrlAlbum { get; set; }
    }
}