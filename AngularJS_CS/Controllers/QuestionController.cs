using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace AngularJS_CS.Controllers
{
    public class QuestionController : Controller
    {
        public Questionnaire Question { get; set; }
        //public Message Message { get; set; }
        // GET: Question
        public IEnumerable<SelectList> Reponses { get; set; }
        public List<Individu> Dests { get; set; }
        public string dests = "";
        public bool indiv = false;
        public bool grp = true;
        public string rep = "";
        public ActionResult Index()
        {
            Dal db = new Dal();
            ViewBag.ListRep = new MultiSelectList(db.Reponses(), "Id", "valeur");
            ViewBag.ListIndividus = new SelectList(db.GetIndividus(), "Id", "userLogin");
            ViewBag.ListGroupe = new SelectList(db.GetGroupes(), "Id", "nom");
            return View(this);
        }

        [WebMethod]
        public ActionResult Addrep()
        {
            new Dal().AddRep(rep);
            rep = "";
            return View();
        }

        [HttpPost]
        public ActionResult Action(Individu Bob)
        {
            Question.Message.Individu1.Add(Bob);
            return View();
        }
    }
}