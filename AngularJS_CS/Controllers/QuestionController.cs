using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using AngularJS_CS.ViewModels;

namespace AngularJS_CS.Controllers
{
    public class QuestionController : Controller
    {
        public Questionnaire Question { get; set; }
        //public Message Message { get; set; }
        // GET: Question

        public ActionResult Index()
        {
            if (HttpContext.Request.IsAuthenticated)
            {
                Dal db = new Dal();
                QuestionView mod = new QuestionView();
                ViewBag.ListRep = new MultiSelectList(db.Reponses(), "Id", "valeur");
                ViewBag.ListIndividus = new SelectList(db.GetIndividus(), "Id", "userLogin");
                ViewBag.ListGroupe = new SelectList(db.GetGroupes(), "Id", "nom");
                ViewBag.ListType = new SelectList(db.GetTypes(), "Id", "type");
                return View(mod);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Ajout(QuestionView mod)
        {
            new Dal().AddRep(mod.Rep);
            return RedirectToAction("Index", "Question");
        }

        [HttpPost]
        public ActionResult Action(QuestionView mod, string id_exp)
        {
            Dal db = new Dal();
            List<Individu> destinataires = new List<Individu>();
            List<Groupe> groupes = new List<Groupe>();
            List<Option_Questionnaire> reponses = new List<Option_Questionnaire>();
            foreach (string str in mod.dests.Split(';'))
                destinataires.Add(db.GetIndividus().FirstOrDefault(i => i.userLogin == str));
            foreach (int i in mod.Reponses)
                reponses.Add(db.Reponses().FirstOrDefault(r => r.Id == i));
            foreach (string str in mod.dests.Split(';'))
                groupes.Add(db.GetGroupes().FirstOrDefault(g => g.nom == str));
            Message content = new Message
            {
                Individu = db.GetIndividus().Find(i => i.Id == int.Parse(id_exp)),
                contenu = mod.detail,
                sujet = mod.sujet,
                Individu1 = destinataires,
                lu = false,
                recu = false,
                Groupe = groupes,
                Id_expediteur = int.Parse(id_exp),
                Id = db.GetLastIdMessage() + 1
            };
            Questionnaire question = new Questionnaire
            {
                Id_message = content.Id,
                Message = content,
                Id = db.GetLastQuestion() + 1,
                Option_Questionnaire = reponses,
                type = mod.type,
                Type_Questionnaire = db.getTypeQuestion(mod.type)
            };
            db.Dispose();
            return RedirectToAction("Index", "Home");
        }
    }
}