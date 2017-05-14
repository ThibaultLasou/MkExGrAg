using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularJS_CS.Models
{   
    /// <summary>
    /// Hub de notifications, chargé de la diffusion (ciblée) des messages.
    /// </summary>
    [HubName("notificationsHub")]
    public class NotificationsHub : Hub
    {
        //Structure singleton pour pas avoir de gros souci.
        private static IHubContext _context = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();

        //cf http://www.tugberkugurlu.com/archive/mapping-asp-net-signalr-connections-to-real-application-users
        //Couples d'Identifiant d'individu - Identifiants SignalR
        private static readonly ConcurrentDictionary<string, int> users = new ConcurrentDictionary<string, int>();

        /// <summary>
        /// Recense le nouveau client connecté.
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            int id;
            using (Dal d = new Dal())
            {
                id = d.GetIndividu(Context.User.Identity.Name).Id;
            }

            //On ajoute chaque client connecté selon son individu (ou id).
            users.TryAdd(Context.ConnectionId, id);
            return base.OnConnected();
        }

        /// <summary>
        /// Supprimme le client déconnecté du registre.
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            int id;
            using (Dal d = new Dal())
            {
                id = d.GetIndividu(Context.User.Identity.Name).Id;
            }

            users.TryRemove(Context.ConnectionId, out int deletedID);   //Novices, voici une déclaration inline.

            if (deletedID != id)
                Console.Error.WriteLine("Individu " + id + "déconnecté par la connexion" + Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// Diffuse une notification aux clients connectés.
        /// </summary>
        /// <param name="m">Message à diffuser.</param>
        /// <param name="destinataires">Liste des indentifiants des destinataires.</param>
        /// <returns>Renvoie la liste des identifiants des clients qui ont effectivement reçu le message.</returns>
        public static HashSet<int> GetNotificationHtml(Message m, HashSet<int> destinataires)
        {
            //Pré-traitement des réponses
            List<string> responses = new List<string>();
            if (m.Questionnaire.Count > 0)
            {
                ICollection<Reponses> r = m.Questionnaire.First().Reponses;
                foreach (Reponses s in r)
                    responses.Add(s.Option_Questionnaire.valeur);
            }

            //On détermine qui est en ligne
            HashSet<int> receivedNotif = new HashSet<int>();
            IList<string> online = new List<string>();

            string signalrID = string.Empty;
            foreach (string key in users.Keys)
            {
                if (destinataires.Contains(users[key]))
                {
                    receivedNotif.Add(users[key]);
                    online.Add(key);
                }
            }


             _context.Clients.All.broadcastNotification(m.Id, m.sujet, m.envoi, m.contenu, m.Questionnaire.Count, responses.ToArray());

            return receivedNotif;
        }
    }
}