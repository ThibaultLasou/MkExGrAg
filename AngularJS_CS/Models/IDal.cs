using AngularJS_CS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS_CS.Models
{
	
	/// <summary>
	/// Interface définissant la Data Access Layer (ou couche d'accès aux données)
	/// </summary>
	public interface IDal : IDisposable
    {
        /// <summary>
        /// Renvoie l'individu correspondant, et ajoute un cookie lié à sa session. Renvoie null si pas d'individu trouvé.
        /// </summary>
        /// <param name="username">Nom d'utilisateur de la session.</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        /// <returns></returns>
        Individu Authenticate(string username, string password);

        /// <summary>
        /// Renvoie tous les individus.
        /// </summary>
        /// <returns></returns>
        List<Individu> GetIndividus();

        /// <summary>
        /// Renvoie tous les groupes.
        /// </summary>
        /// <returns></returns>
        List<Groupe> GetGroupes();

        /// <summary>
        /// Renvoie toutes les réponses.
        /// </summary>
        /// <returns></returns>
        List<Option_Questionnaire> Reponses();
        /// <summary>
        /// Renvoie un document web, identifié par son nom.
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        Doc_Web ObtenirDoc(string nom);
        /// <summary>
        /// Renvoie l'identifiant du dernier message.
        /// </summary>
        /// <returns></returns>
        int GetLastIdMessage();
        /// <summary>
        /// Renvoie l'identifiant de la dernière question.
        /// </summary>
        /// <returns></returns>
        int GetLastQuestion();
        /// <summary>
        /// Renvoie tous les types de questionnaires.
        /// </summary>
        /// <returns></returns>
        List<Type_Questionnaire> GetTypes();
        /// <summary>
        /// Renvoie le nom d'un individu à partir de son identifiant unique.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetName(string userId);
        /// <summary>
        /// Renvoie toutes les réponses.
        /// </summary>
        /// <returns></returns>
        List<Reponses> GetRep();
        /// <summary>
        /// Sauvegarde les modifications de la base de données.
        /// </summary>
        void Savedb();

        /// <summary>
        /// Renvoi l'individu dont l'ID correspondant à cette ID dans la base de données
        /// </summary>
        /// <param name="identifier">Identifiant unique de l'utilisateur.</param>
        /// <returns></returns>
        Individu GetIndividu(string identifier);

        /// <summary>
        /// Renvoi l'individu dont l'ID correspondant à cette ID dans la base de données
        /// </summary>
        /// <param name="identifier">Identifiant unique de l'utilisateur.</param>
        /// <returns></returns>
        Individu GetIndividu(int identifier);

        /// <summary>
        /// Renvoie les identifiants uniques de chaque destinataire.
        /// </summary>
        /// <param name="m">Message dont les destinataires sont recherchés.</param>
        /// <returns></returns>
        HashSet<int> GetIdsDestinataires(QuestionViewModel m);
    }
}
