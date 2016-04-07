using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assigment8.Controllers
{
    public class RoleClaimBase
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }
    }
}