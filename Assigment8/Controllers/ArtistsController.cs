using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assigment8.Controllers
{
    public class ArtistsController : Controller
    {
        private Manager m = new Manager();

        // GET: Artists
        public ActionResult Index()
        {
            var artists = m.ArtistGetAllWithDetail();
            return View(artists);
        }
    }
}