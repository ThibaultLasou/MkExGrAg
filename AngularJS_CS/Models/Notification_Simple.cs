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
    
    public partial class Notification_Simple
    {
        public int Id { get; set; }
        public int Id_message { get; set; }
        public int Id_individu { get; set; }
    
        public virtual Individu Individu { get; set; }
        public virtual Message Message { get; set; }
    }
}
