using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}