using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assigment8.Controllers
{
    public class MediaItemAddForm
    {
        public int ArtistId { get; set; }

        [Display(Name = "Artist information")]
        public string ArtistInfo { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Media")]
        [DataType(DataType.Upload)]
        public string MediaUpload { get; set; }
    }

    public class MediaItemAdd
    {
        public int ArtistId { get; set; }

        [Required, StringLength(100)]
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase MediaUpload { get; set; }
    }

    public class MediaItemBase
    {
        public int Id { get; set; }

        [Display(Name = "Added on date/time")]
        public DateTime Timestamp { get; set; }

        // For the generated identifier
        [Required, StringLength(100)]
        [Display(Name = "Unique identifier")]
        public string StringId { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }
    }

    public class MediaItemContent
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}