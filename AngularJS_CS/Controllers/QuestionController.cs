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

            };
            foreach (int i in mod.Reponses)
            {
                var opt = db.Reponses()[i - 1];
                int idrep = db.GetRep().Count;
                idrep += i;
                Reponses rep = new Reponses
                {
                    Questionnaire = question,
                    Id = idrep,
                    Id_question = question.Id,
                    Id_reponse = i,
                    Option_Questionnaire = opt
                };
                db.Addreponse(rep);
                opt.Reponses.Add(rep);
                question.Reponses.Add(rep);
            }

            db.GetIndividus().Find(i => i.Id == int.Parse(User.Identity.Name)).Message.Add(content);
            db.GetQuestion().Add(question);
            db.AddMessage(content);

            question.Message = content;
            foreach (Individu ind in destinataires)
                if (ind != null)
                {
                    Notification_Simple notif = new Notification_Simple
                    {
                        Id_individu = ind.Id,
                        Individu = ind,
                        Id_message = content.Id,
                        Message = content
                    };
                    ind.Notification_Simple.Add(notif);
                    content.Notification_Simple.Add(notif);
                }
            foreach (Groupe gr in groupes)
                if (gr != null)
                {
                    Notification_Diffusion not = new Notification_Diffusion
                    {
                        Id_groupe = gr.Id,
                        Groupe = gr,
                        Id_message = content.Id,
                        Message = content,
                    };
                    gr.Notification_Diffusion.Add(not);
                    content.Notification_Diffusion.Add(not);
                }

            content.Questionnaire.Add(question);
            db.Savedb();
            NotificationsHub.GetNotificationHtml(content, db.GetIdsDestinataires(mod));
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult Read(AnswerView mod)
        {
            int laappa = 0;
            return RedirectToAction("Index", "Question");

        }

        [HttpPost]
        public ActionResult Retorque(AnswerView mod)
        {
            Dal db = new Dal();
            Individu receveur = db.GetIndividus().Find(i => i.Id == mod.dest);
            Individu sender = db.GetIndividus().Find(i => i.Id == int.Parse(User.Identity.Name));
            sender.Notification_Simple.FirstOrDefault(m => m.Id_message == mod.id_message && m.Id_individu ==int.Parse(User.Identity.Name)).Message.lu = true;
            sender.Notification_Simple.First(m => m.Id_message == mod.id_message && m.Id_individu == int.Parse(User.Identity.Name)).Message.lecture = System.DateTime.Now;
            Message rep = new Message
            {
                Individu = sender,
                contenu = db.Reponses().Find(q=>q.Id ==mod.repchosen).valeur+"\n"+ mod.rep,
                envoi = System.DateTime.Now,
                lecture = System.DateTime.Now,
                recu = false,
                lu = false,
                Id_expediteur = sender.Id,
                Questionnaire = null,
                sujet = mod.subject.StartsWith("Re:") ? mod.subject : "Re:" + mod.subject,                
            };
            Notification_Simple notif = new Notification_Simple
            {
                Id_individu = int.Parse(User.Identity.Name),
                Id_message =rep.Id,
                Individu = sender,
                Message = rep,
            };
            sender.Notification_Simple.Add(notif);
            rep.Notification_Simple.Add(notif);
            db.Savedb();
            return RedirectToAction(mod.actualurl);
        }
    }
}