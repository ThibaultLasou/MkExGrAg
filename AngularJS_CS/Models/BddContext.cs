using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJS_CS.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Individu> Individus { get; set; }
    }
}