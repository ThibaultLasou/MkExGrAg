using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJS_CS.Models
{
    public class Dal : IDal
    {
        private MainDBEntities5 bdd;
        public Dal()
        {
            bdd = new MainDBEntities5();
        }

        public Individu Authenticate(string username, string password)
        {
            foreach (Individu ind in bdd.Individu)
                if (ind.userLogin == username && ind.numCarte == password)
                    return ind;
            return null;
        }

        public void Dispose()
        {
            bdd.Dispose();
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
