using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeTheExtranetGreatAgain.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        // GET: TVShow
        public ActionResult Home()
        {
            return View();
        }
    }
}