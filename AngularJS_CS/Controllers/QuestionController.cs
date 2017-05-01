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
        public  string Rep = "";
        public ActionResult Index()
        {
            Dal db = new Dal();
            var mod =  new QuestionController();
            ViewBag.ListRep = new MultiSelectList(db.Reponses(), "Id", "valeur");
            ViewBag.ListIndividus = new SelectList(db.GetIndividus(), "Id", "userLogin");
            ViewBag.ListGroupe = new SelectList(db.GetGroupes(), "Id", "nom");
            db.Dispose();
            return View(mod);
        }

        [HttpPost]
        public ActionResult Index(object b = null)
        {
           new Dal().AddRep(ValueProvider.GetValue("Rep").AttemptedValue);
            return View();
        }

        
        public ActionResult Action(Individu Bob)
        {
            Question.Message.Individu1.Add(Bob);
            return View();
        }
    }
}