using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AngularJS_CS.ViewModels
{
    public class QuestionView 
    {
        public bool question { get; set; }
        [Required]
        public string Dests { get; set; }
        public string Sujet { get; set; }
        public string Detail { get; set; }
        public IEnumerable<int> Reponses { get; set; }
        public int Type { get; set; }
        public string Rep { get; set; }
    }
}
