//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularJS_CS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Creneau
    {
        public System.DateTime debut { get; set; }
        public System.DateTime fin { get; set; }
        public int Id_Salle { get; set; }
        public int Id_Activite { get; set; }
    
        public virtual Activite Activite { get; set; }
        public virtual Salle Salle { get; set; }
    }
}
