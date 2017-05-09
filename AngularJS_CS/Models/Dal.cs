using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJS_CS.Models
{
    public class Dal : IDal
    {
        private MainDBEntities bdd;
        public Dal()
        {
            bdd = new MainDBEntities();
        }

        ~Dal()
        {
            this.Dispose();
        }

        public Individu Authenticate(string username, string password)
        {
            return bdd.Individu.FirstOrDefault(ind => ind.userLogin == username && ind.numCarte == password);

            //Individu res = (from ind in bdd.Individu
            //                where ind.userLogin == username && ind.numCarte == password
            //                select ind).FirstOrDefault();
            //return res;

            //foreach (Individu ind in bdd.Individu)
            //    if (ind.userLogin == username && ind.numCarte == password)
            //        return ind;
            //return null;
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public Doc_Web ObtenirDoc(string nom)
        {
            throw new NotImplementedException();
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
            if (rep != "" && rep != null)
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

        public string GetName(string strId)
        {
            int id = -1;
            int.TryParse(strId, out id);
            Individu ind = bdd.Individu.FirstOrDefault(i => i.Id == id);

            return ind?.prenom ?? "Individu inconnu";
        }
    }
}
