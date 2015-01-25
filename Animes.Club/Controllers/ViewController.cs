using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Animes.Club.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Template(String folder, String file)
        {
            return PartialView(String.Format("~/Views/{0}/{1}.cshtml", folder, file));
        }
    }
}