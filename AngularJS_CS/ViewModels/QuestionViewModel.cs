using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AngularJS_CS.ViewModels
{
    /// <summary>
    /// Modèle de données pour la création d'un questionnaire
    /// </summary>
    public class QuestionViewModel 
    {
        /// <summary>
        /// Indique s'il s'agit bien d'un questionnaire.
        /// </summary>
        public bool question { get; set; }
        /// <summary>
        /// Chaîne contenant les destinataires, séparés par un ';'.
        /// </summary>
        [Required]
        public string Dests { get; set; }
        /// <summary>
        /// Sujet du questionnaire.
        /// </summary>
        public string Sujet { get; set; }
        /// <summary>
        /// Détail du questionnaire.
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// Identifiants uniques des réponses.
        /// </summary>
        public IEnumerable<int> Reponses { get; set; }
        /// <summary>
        /// Identifiant du type unique du questionnaire.
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Réponse du questionnaire.
        /// </summary>
        public string Rep { get; set; }
    }
}
