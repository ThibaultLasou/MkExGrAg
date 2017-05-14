using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJS_CS.Controllers
{
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        public ActionResult Doc(string id)
        {
            if(id != null)
            {
                Doc_Web doc = new Doc_Web();
/*                using (IDal dal = new Dal())
                {
                    try
                    {
                        doc = dal.ObtenirDoc(id);
                    }
                    catch (NotImplementedException)
                    {
  */                      doc.nom = id;
                        Sous_doc_Web sub = new Sous_doc_Web();
                        sub.contenu_html = "<h1>BLBLBLBLBLLB</h1>\n<p>lalalalala</p>";
                        doc.Sous_doc_Web.Add(sub);
                        Sous_doc_Web sub2 = new Sous_doc_Web();
                        sub2.contenu_html = "<h2>BLBLBLBLBLLB</h2><p>lalalalala</p>";
                        doc.Sous_doc_Web.Add(sub2);
/*                    }
                }
*/                if (doc != null)
                {
                    ViewData["Doc"] = doc;
                    return View();
                }
            }
            return View("Index", "Error");
        }
        //Ne fonctionne pas.
        //[HttpPost]
        //public JsonResult CreateIndividu(Individus model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Data save to database  
        //        return Json(new
        //        {
        //            success = true
        //        });
        //    }
        //    return Json(new
        //    {
        //        success = false,
        //        errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
        //    });
        //}
    }
}