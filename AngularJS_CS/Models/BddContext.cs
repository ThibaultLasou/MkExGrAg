using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AngularJS_CS.Models
{
    public class BddContext: DbContext
    {
        public DbSet<Individu>Individus { get; set; }
        public DbSet<Option_Questionnaire> Reponses { get; set; }
    }
}