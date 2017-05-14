using AngularJS_CS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS_CS.Models
{
    //Interface définissant la Data Access Layer (ou couche d'accès aux données)
    public interface IDal : IDisposable
    {
        Individu Authenticate(string username, string password);


        List<Individu> GetIndividus();

        List<Groupe> GetGroupes();

        List<Option_Questionnaire> Reponses();
        Doc_Web ObtenirDoc(string nom);
        int GetLastIdMessage();
        int GetLastQuestion();
        List<Type_Questionnaire> GetTypes();
        string GetName(string id);
        List<Reponses> GetRep();
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
        HashSet<int> GetIdsDestinataires(QuestionView m);
    }
}
