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
        public ActionResult Action(QuestionView mod)
        {
            Dal db = new Dal();
            List<Individu> destinataires = new List<Individu>();
            List<Groupe> groupes = new List<Groupe>();
            foreach (string str in mod.dests.Split(';'))
                destinataires.Add(db.GetIndividus().FirstOrDefault(i => i.userLogin == str));

            foreach (string str in mod.dests.Split(';'))
                groupes.Add(db.GetGroupes().FirstOrDefault(g => g.nom == str));
            Message content = new Message
            {
                Individu = db.GetIndividus().Find(i => i.Id == int.Parse(User.Identity.Name)),
                contenu = mod.detail,
                sujet = mod.sujet,
                lu = false,
                recu = false,
                Groupe = groupes,
                Id_expediteur = int.Parse(User.Identity.Name),
                Id = db.GetLastIdMessage() + 1,
                envoi = System.DateTime.Now,
                lecture = System.DateTime.Now
            };
            Questionnaire question = new Questionnaire
            {
                Id = db.GetLastQuestion() + 1,
                type = mod.type,
                Type_Questionnaire = db.getTypeQuestion(mod.type),
                Id_message = content.Id,
                Option_Questionnaire = new List<Option_Questionnaire>(),
            };
            foreach (int i in mod.Reponses)
            {
                var opt = db.Reponses()[i - 1];
                question.Option_Questionnaire.Add(opt);
                opt.Questionnaire.Add(question);
                //question.Option_Questionnaire.Add(new Option_Questionnaire { Id = i, valeur = db.Reponses().FirstOrDefault(r => r.Id == i).valeur });
                //db.Reponses().FirstOrDefault(r => r.Id == i).Questionnaire.Add(db.GetQuestion()[db.GetQuestion().Count - 1]);
            }

            db.GetIndividus().Find(i => i.Id == int.Parse(User.Identity.Name)).Message.Add(content);
            db.GetQuestion().Add(question);
            db.AddMessage(content);
            //db.AddQuesiton(question);
            db.Savedb();

            //db.AddMessage(content);
            //db.AddQuesiton(question);
            db.Savedb();
            question.Message = content;
            db.Savedb();
            foreach (Individu ind in destinataires)
                if (ind != null)
                {
                    ind.Message1.Add(content);
                    content.Individu1.Add(ind);
                }

            content.Questionnaire.Add(question);
            db.Savedb();
            db.Dispose();
            return RedirectToAction("Index", "Home");

        }
    }
}