using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_CS.ViewModels
{
    /// <summary>
    /// Modèle de données d'une réponse à une question.
    /// </summary>
    public class AnswerViewModel
    {
        /// <summary>
        /// Réponse textuelle entrée par l'utilisateur.
        /// </summary>
        [Required]
        public string Rep { get; set; }
        /// <summary>
        /// Réponse choisie dans une liste déroulante par l'utilisateur.
        /// </summary>
        [Required]
        public int Repchosen { get; set; }
        /// <summary>
        /// Identifiant du destinataire.
        /// </summary>
        public int Dest { get; set; }
        /// <summary>
        /// Identifiant du message auquel on a répondu.
        /// </summary>
        public int Id_message { get; set; }
        /// <summary>
        /// Sujet du message.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// URL de la page source de la réponse.
        /// </summary>
        public string Actualurl { get; set; }
        /// <summary>
        /// Notification source de la réponse
        /// </summary>
        public Notification_Simple Not { get; set; }
        /// <summary>
        /// Initialise le viewModel de la réponse.
        /// </summary>
        /// <param name="notif">Notification permettant d'initialiser le viewModel </param>
        /// <returns></returns>
        public AnswerViewModel Init(Notification_Simple notif)
        {
            var ret = new AnswerViewModel() { Not = notif };
            return ret;
        }
    }
}