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
        public Dal() { bdd = new MainDBEntities5(); }

        ~Dal() { this.Dispose(); }

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

        public void Dispose() { bdd.Dispose(); }

        public Doc_Web ObtenirDoc(string nom)
        {
            throw new NotImplementedException();
        }

        public List<Groupe> GetGroupes() { return bdd.Groupe.ToList(); }

        public List<Individu> GetIndividus() { return bdd.Individu.ToList(); }

        public Individu ObtenirInidividu()
        {
            throw new NotImplementedException();
        }
        public List<Questionnaire> GetQuestion() { return bdd.Questionnaire.ToList(); }
        public List<Option_Questionnaire> Reponses() { return bdd.Option_Questionnaire.ToList(); }
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
        public void AddMessage(Message m) { bdd.Message.Add(m); }
        public int GetLastIdMessage()
        {
            if (bdd.Message.Count() > 0)
                return bdd.Message.ToList()[bdd.Message.Count() - 1].Id;
            return 0;
        }
        public void AddQuesiton(Questionnaire q) { bdd.Questionnaire.Add(q); }
        public int GetLastQuestion()
        {
            if (bdd.Questionnaire.Count() >= 1)
                return bdd.Questionnaire.ToList()[bdd.Questionnaire.Count() - 1].Id;
            return 0;
        }
        public Type_Questionnaire getTypeQuestion(int id) { return bdd.Type_Questionnaire.Find(id); }
        public List<Type_Questionnaire> GetTypes() { return bdd.Type_Questionnaire.ToList(); }

        public void Savedb() { bdd.SaveChanges(); }
        public void Addreponse(Reponses rep) { bdd.Reponses.Add(rep); }
        public List<Reponses> GetRep() { return bdd.Reponses.ToList(); }
    }
}
