using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Animes.Club.Controllers
{
    public class ListsController : Controller
    {
        public ActionResult Watching()
        {
            return PartialView();
        }

        public ActionResult Completed()
        {
            return PartialView();
        }

        public ActionResult Dropped()
        {
            return PartialView();
        }

        public ActionResult Todo()
        {
            return PartialView();
        }
    }
}