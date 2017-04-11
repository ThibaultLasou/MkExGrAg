using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AngularJS_CS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateCustomer(Individus model)
        {
            if (ModelState.IsValid)
            {
                //Data save to database  
                return Json(new
                {
                    success = true
                });
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }
    }
}