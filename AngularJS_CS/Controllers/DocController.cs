using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AngularJS_CS.Models;

namespace AngularJS_CS.Controllers
{
    public class DocController : Controller
    {
        public ActionResult Show(string doc)
        {
            if (doc != null)
            {
                IDal dal = new Dal();
                Doc_Web docu;
                Individu i = null;
                if (!HttpContext.Request.IsAuthenticated)
                {
                    docu = dal.ObtenirDoc(doc, null);
                }
                else
                {
                    i = dal.GetIndividu(HttpContext.User.Identity.Name);
                    docu = dal.ObtenirDoc(doc, i.Groupe.FirstOrDefault());
                }
                if (docu != null)
                {
                    ViewData["Doc"] = docu;
                    ViewData["Ind"] = i;
                    return View();
                }
            }
            return View("Error");
        }
    }
}