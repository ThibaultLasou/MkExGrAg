using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Groupe> GetGroupes()
        {
            return bdd.Groupe.ToList();
        }

        public List<Individu> GetIndividus()
        {
            return bdd.Individu.ToList();
        }

        public Individu ObtenirInidividu()
        {
            throw new NotImplementedException();
        }

        public List<Option_Questionnaire> Reponses()
        {
            return bdd.Option_Questionnaire.ToList();
        }
        public void AddRep(string rep)
        {
            if (rep != "")
            {
                Option_Questionnaire nrep = new Option_Questionnaire()
                {
                    valeur = rep
                };
                if (bdd.Option_Questionnaire.Count() > 0)
                    nrep.Id = bdd.Option_Questionnaire.ToList()[bdd.Option_Questionnaire.Count() - 1].Id + 1;
                else
                    nrep.Id = 1;
                bdd.Option_Questionnaire.Add(nrep);
                bdd.SaveChanges();
            }
        }
    }
}