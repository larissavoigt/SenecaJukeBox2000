using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assigment8.Controllers
{
    public class TrackClipsController : Controller
    {
        Manager m = new Manager();

        // GET: Clip/5
        // Attention - 8 - Uses attribute routing
        [Route("clip/{id}")]
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var o = m.TrackClipGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Clip, o.ClipContentType);
            }
        }
    }
}