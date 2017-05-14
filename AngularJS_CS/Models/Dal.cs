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

		/// <summary>
		/// Destructeur 
		/// </summary>
        ~Dal() { this.Dispose(); }

		/// <summary>
		/// Logger un utilisateur 
		/// </summary>
		/// <param name="username">identifiant de l'utilisateur</param>
		/// <param name="password">mot de passe de l'utilisateur</param>
		/// <returns>Retourne l'individu qui correspond à l'id et au mot de passe passés en paramètre</returns>
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

		/// <summary>
		/// 
		/// </summary>
        public void Dispose() { bdd.Dispose(); }

		/// <summary>
		/// Récupeère la documentation
		/// </summary>
		/// <param name="nom"></param>
		/// <returns>Retourne la documentation </returns>
        public Doc_Web ObtenirDoc(string nom)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Récupère la liste des groupes à partir de la base de données
		/// </summary>
		/// <returns>Retourne la liste de groupes </returns>
        public List<Groupe> GetGroupes() { return bdd.Groupe.ToList(); }

		/// <summary>
		/// Récupère la liste des individus à partir de la base de données
		/// </summary>
		/// <returns>Retourne la liste d'individus</returns>
		public List<Individu> GetIndividus() { return bdd.Individu.ToList(); }

		/// <summary>
		/// Sert à obtenir un individu, lance une exception
		/// </summary>
		/// <returns></returns>
        public Individu ObtenirInidividu()
        {
            throw new NotImplementedException();
        }

		/// <summary>
		///  Récupère la liste des questionnaires à partir de la base de données
		/// </summary>
		/// <returns>Retourne la liste de questionnairess</returns>
		public List<Questionnaire> GetQuestion() { return bdd.Questionnaire.ToList(); }

		/// <summary>
		///  Récupère la liste des options des questionnaires à partir de la base de données
		/// </summary>
		/// <returns>Retourne la liste des options des questionnaires></returns>
		public List<Option_Questionnaire> Reponses() { return bdd.Option_Questionnaire.ToList(); }

		/// <summary>
		/// Ajouter une option à un questionnaire
		/// </summary>
		/// <param name="rep">nom de l'option</param>
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

		/// <summary>
		/// Recupère le nom d'un individu à partir de son id
		/// </summary>
		/// <param name="strId">id de l'individu</param>
		/// <returns>Retourne le nom de l'individu</returns>
        public string GetName(string strId)
        {
            int id = -1;
            int.TryParse(strId, out id);
            Individu ind = bdd.Individu.FirstOrDefault(i => i.Id == id);

            return ind?.prenom ?? "Individu inconnu";
        }

		/// <summary>
		/// Ajouter un message
		/// </summary>
		/// <param name="m">message à ajouter</param>
        public void AddMessage(Message m) { bdd.Message.Add(m); }

		/// <summary>
		/// Recupère l'identifiant du dernier message 
		/// </summary>
		/// <returns></returns>
        public int GetLastIdMessage()
        {
            if (bdd.Message.Count() > 0)
                return bdd.Message.ToList()[bdd.Message.Count() - 1].Id;
            return 0;
        }

		/// <summary>
		/// Ajouter questionnaire
		/// </summary>
		/// <param name="q">questionnaire à ajouter</param>
        public void AddQuesiton(Questionnaire q) { bdd.Questionnaire.Add(q); }
        public int GetLastQuestion()
        {
            if (bdd.Questionnaire.Count() >= 1)
                return bdd.Questionnaire.ToList()[bdd.Questionnaire.Count() - 1].Id;
            return 0;
        }

		/// <summary>
		/// Récupère le type du questionnaire à partir d'un id
		/// </summary>
		/// <param name="id">id du questionnaire dont on cherche le type</param>
		/// <returns></returns>
        public Type_Questionnaire getTypeQuestion(int id) { return bdd.Type_Questionnaire.Find(id); }

		/// <summary>
		/// Récupère la liste de types des questionnaires disponibles dans la BDD
		/// </summary>
		/// <returns></returns>
        public List<Type_Questionnaire> GetTypes() { return bdd.Type_Questionnaire.ToList(); }

		/// <summary>
		/// Met à jour les changements de la BDD
		/// </summary>
        public void Savedb() { bdd.SaveChanges(); }

		/// <summary>
		/// Ajouter une réponse à la liste des réponses de la BDD
		/// </summary>
		/// <param name="rep">Réponse à ajouter dans la BDD</param>
        public void Addreponse(Reponses rep) { bdd.Reponses.Add(rep); }

		/// <summary>
		/// Récupère la liste des réponses à partir de la base de données
		/// </summary>
		/// <returns></returns>
        public List<Reponses> GetRep() { return bdd.Reponses.ToList(); }
    }
}
