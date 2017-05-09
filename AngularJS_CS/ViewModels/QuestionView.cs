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

        public string dests { get; set; }
        [MaxLength(40)]
        public string sujet { get; set; }
        public string detail { get; set; }
        public IEnumerable<int> Reponses { get; set; }
        public int type { get; set; }
        public string Rep { get; set; }
    }
}
