using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJS_CS.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;
        public Dal()
        {
            bdd = new BddContext();
        }

        public Individu Authenticate(string username, string password)
        {
            foreach (Individu ind in bdd.Individus)
                if (ind.userLogin == username && ind.numCarte == password)
                    return ind;
            return null;
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public Individu ObtenirIndividu()
        {
            throw new NotImplementedException();
        }
    }
}