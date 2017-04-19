using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJS_CS.Models
{
    public class Dal : IDal
    {
        public Dal()
        {

        }

        public Individu Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Doc_Web ObtenirDoc(string nom)
        {
            throw new NotImplementedException();
        }

        public Individu ObtenirIndividu()
        {
            throw new NotImplementedException();
        }
    }
}
