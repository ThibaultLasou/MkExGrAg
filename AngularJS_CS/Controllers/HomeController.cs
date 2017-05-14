using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJS_CS.Controllers
{
    /// <summary>
    /// Controlleur de la page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(string id)
        {
            if (id == null)
                return View();
            else
                return View("Error");
        }
    }
}
