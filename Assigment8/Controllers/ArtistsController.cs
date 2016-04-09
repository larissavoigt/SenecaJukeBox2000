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

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Artists/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddForm();

            form.GenreList = new SelectList
                    (items: m.GenreGetAll(),
                    dataValueField: "Name",
                    dataTextField: "Name");

            return View(form);
        }

        // POST: Artists/Create
        [HttpPost, ValidateInput(false)]
        [Authorize(Roles = "Executive")]
        public ActionResult Create(ArtistAdd newItem)
        {
            newItem.Executive = HttpContext.User.Identity.Name;
            ModelState.Clear();

            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        // GET: Artists/5/AddMediaItem
        [Route("artists/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            // Attempt to get the matching object
            var o = m.ArtistGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Create a form
                var form = new MediaItemAddForm();
                // Configure its property values
                form.ArtistId = o.Id;
                form.ArtistInfo = $"{o.Name}";

                // Pass the object to the view
                return View(form);
            }
        }

        // POST: Artists/5/AddMediaItem
        [HttpPost]
        [Route("artists/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id, MediaItemAdd newItem)
        {
            // Validate the input
            // Two conditions must be checked
            if (!ModelState.IsValid && id.GetValueOrDefault() == newItem.ArtistId)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }

    }
}