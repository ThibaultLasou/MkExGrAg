﻿using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJS_CS.Controllers
{
    public class QuestionController : Controller
    {
        public Questionnaire Question { get; set; }
        //public Message Message { get; set; }
        // GET: Question
        public IEnumerable<SelectList> reponses { get; set; }
        public List<Individu> Dests { get; set; }
        public MainDBEntities5 db = new MainDBEntities5();


        public ActionResult Index()
        {
            ViewBag.ListRep = new MultiSelectList(db.Option_Questionnaire.ToList(), "Id", "valeur");
            ViewBag.ListIndividus = new SelectList(db.Individu.ToList(), "Id", "userLogin");
            return View();
        }
    }
}