﻿using AngularJS_CS.Models;
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
        private Dal db = new Dal();
        public ActionResult Index()
        {
            QuestionView mod =  new QuestionView();
            ViewBag.ListRep = new MultiSelectList(db.Reponses(), "Id", "valeur");
            ViewBag.ListIndividus = new SelectList(db.GetIndividus(), "Id", "userLogin");
            ViewBag.ListGroupe = new SelectList(db.GetGroupes(), "Id", "nom");
            return View(mod);
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
            string dest = ValueProvider.GetValue("dests").AttemptedValue;
            string sujet = ValueProvider.GetValue("sujet").AttemptedValue;
            string detail = ValueProvider.GetValue("detail").AttemptedValue;
            string reps = ValueProvider.GetValue("Reponses").AttemptedValue;
            db.Dispose();
            return RedirectToAction("Index", "Home");
        }
    }
}