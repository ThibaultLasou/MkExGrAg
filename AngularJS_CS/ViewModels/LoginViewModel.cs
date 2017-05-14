using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_CS.ViewModels
{
    /// <summary>
    /// Modèle de données pour l'identification
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Identifiant unique de l'utilisateur. Longueur maximale : 8
        /// </summary>
        [Required]
        [MaxLength(8)]
        [Display(Name = "Identifiant")]
        public string UserID { get; set; }

        /// <summary>
        /// Identifiant unique de l'utilisateur. Longueur exacte : 8, doit être composé de chiffres exclusivement.
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Numéro de carte")]
        public string Password { get; set; }

        //[Display(Name = "Mémoriser le mot de passe ?")]
        //public bool RememberMe { get; set; }

        //public bool Authenticated { get; set; }
    }
}