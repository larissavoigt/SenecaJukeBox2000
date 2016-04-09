using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assigment8.Controllers
{
    public class AlbumsController : Controller
    {
        private Manager m = new Manager();

        // GET: Albums
        public ActionResult Index()
        {
            var albums = m.AlbumGetAllWithDetail();
            return View(albums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.AlbumGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Albums/Create
        [Authorize(Roles = "Coordinator")]
        public ActionResult Create(int? id)
        {
            // Attempt to fetch the matching object
            var a = m.ArtistGetById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.ArtistName = a.Name;
                ViewBag.ArtistId = a.Id;

                var form = new AlbumAddForm();

                form.GenreList = new SelectList
                    (items: m.GenreGetAll(),
                    dataValueField: "Name",
                    dataTextField: "Name");

                return View(form);
            }

        }

        // POST: Albums/Create
        [Authorize(Roles = "Coordinator")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(AlbumAdd newItem)
        {
            newItem.Coordinator = HttpContext.User.Identity.Name;
            ModelState.Clear();

            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = m.AlbumAdd(newItem);

            if (addedItem == null)
            {

                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }
    }
}