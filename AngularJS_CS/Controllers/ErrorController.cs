using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJS_CS.Controllers
{
    public sealed class ErrorController : Controller
    {
        
		/// <summary>
		/// Cas declenché en cas d'erreur
		/// </summary>
		/// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}