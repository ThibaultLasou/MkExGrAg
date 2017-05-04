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

        [Required]
        public string dests { get; set; }
        [Required]
        [MaxLength(40)]
        public string sujet { get; set; }
        public List<Individu> Dests { get; set; }
        public string detail { get; set; }
        [Required]
        public List<Option_Questionnaire> Reponses { get; set; }

        public string Rep { get; set; }
    }
}
