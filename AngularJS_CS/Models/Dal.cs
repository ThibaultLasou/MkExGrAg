using AngularJS_CS.ViewModels;
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
        public Dal() { bdd = new MainDBEntities(); }

        ~Dal() { this.Dispose(); }

        public Individu Authenticate(string username, string password)
        {
            return bdd.Individu.FirstOrDefault(ind => ind.userLogin == username && ind.numCarte == password);
        }

        public void Dispose() { bdd.Dispose(); }

        public Doc_Web ObtenirDoc(string nom)
        {
            throw new NotImplementedException();
        }

        public List<Groupe> GetGroupes() { return bdd.Groupe.ToList(); }

        public List<Individu> GetIndividus() { return bdd.Individu.ToList(); }

        /// <summary>
        /// Renvoi l'individu dont l'ID correspondant à cette ID dans la base de données
        /// </summary>
        /// <param name="identifier">Identifiant unique de l'utilisateur.</param>
        /// <returns></returns>
        public Individu GetIndividu(string identifier)
        {
            int id = -1;
            int.TryParse(identifier, out id);
            return GetIndividu(id);
        }

        /// <summary>
        /// Renvoi l'individu dont l'ID correspondant à cette ID dans la base de données
        /// </summary>
        /// <param name="identifier">Identifiant unique de l'utilisateur.</param>
        /// <returns></returns>
        public Individu GetIndividu(int identifier)
        {
            return bdd.Individu.FirstOrDefault(indiv => indiv.Id == identifier);
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

        /// <summary>
        /// Renvoie les identifiants uniques de chaque destinataire.
        /// </summary>
        /// <param name="m">Message dont les destinataires sont recherchés.</param>
        /// <returns></returns>
        public HashSet<int> GetIdsDestinataires(QuestionView mod)
        {
            List<string> destinataires = mod.dests.Split(';').ToList();
            HashSet<int> set = new HashSet<int>();
            
            //On ne prend que ceux qui étaient dans la liste de destinataires
            set.UnionWith(from ind in bdd.Individu
                          where destinataires.Contains(ind.userLogin) == true
                          select ind.Id);
           

            //Il ne reste que les groupes à traiter
            IEnumerable<Groupe> grps = from grp in bdd.Groupe
                                       where destinataires.Contains(grp.nom)
                                       select grp;

            set.UnionWith(from g in grps
                          from ind in g.Individu
                          select ind.Id);

            return set;
        }
    }
}
