using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_CS.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(80)]
        [Display(Name = "Identifiant")]
        public string UserID { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Numéro de carte")]
        public string Password { get; set; }

        [Display(Name = "Mémoriser le mot de passe ?")]
        public bool RememberMe { get; set; }

        public bool Authenticated { get; set; }
    }
}