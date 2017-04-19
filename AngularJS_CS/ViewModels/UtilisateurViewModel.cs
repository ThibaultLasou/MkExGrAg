using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJS_CS.ViewModels
{
    public class UtilisateurViewModel
    {
        public string Login
        {
            get
            {
                string s1 = Individu.nom,
                    s2 = Individu.prenom;

                return s1.Substring(0, Math.Min(4, s1.Length))
                    + s2.Substring(0, Math.Min(4, s2.Length));
            }
        }

        public int NumCarte { get; }

        public Individu Individu { get; set; }
        public bool Authenticated { get; set; }
    }
}