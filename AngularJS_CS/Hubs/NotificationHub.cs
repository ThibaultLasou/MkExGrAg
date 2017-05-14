using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularJS_CS.Models
{
    [System.Web.Mvc.Authorize]
    public class NotificationsHub : Hub
    {
        //cf http://www.tugberkugurlu.com/archive/mapping-asp-net-signalr-connections-to-real-application-users
        //Couples d'Identifiant d'individu - Identifiants SignalR
        private static readonly ConcurrentDictionary<int, string> users = new ConcurrentDictionary<int, string>();

        public override Task OnConnected()
        {
            int id;
            using (Dal d = new Dal())
            {
                id = d.GetIndividu(Context.User.Identity.Name).Id;
            }

            //On ajoute chaque client connecté selon son individu (ou id).
            users.TryAdd(id, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            int id;
            string connexionId;
            using (Dal d = new Dal())
            {
                id = d.GetIndividu(Context.User.Identity.Name).Id;
            }

            users.TryRemove(id, out connexionId);

            if (connexionId != Context.ConnectionId)
                Console.Error.WriteLine("Individu " + id + "déconnecté par la connexion" + connexionId);

            return base.OnDisconnected(stopCalled);
        }

        public void SendNotification(string author, string message)
        {
            //Clients.Clients()
            Clients.All.broadcastNotification(author, message);
        }

        public void DiffuseQuestionnaire()
        {
            Clients.All.broadcastNotification("MyFavAdmin", "Hello");
        }

        /// <summary>
        /// Diffuse une notification aux clients connectés.
        /// </summary>
        /// <param name="n">Notification à diffuser.</param>
        /// <returns>Renvoie la liste des identifiants des clients qui ont effectivement reçu le message.</returns>
        public HashSet<int> GetNotificationHtml(Notification_Simple n)
        {
            //Voir pour utiliser ClientExclude
            //Clients.AllExcept(.All.personnalMessage(n);
            return null;
        }
    }
}