using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJS_CS.Models
{
    public class NotificationsHub : Hub
    {
        public void SendNotification(string author, string message)
        {
            //Clients.Clients()
            Clients.All.broadcastNotification(author, message);
        }

        public void DiffuseQuestionnaire()
        {
            Clients.All.broadcastNotification("MyFavAdmin", "Hello");
        }
    }
}