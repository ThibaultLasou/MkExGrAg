using AngularJS_CS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJS_CS.ViewModels
{
    public class AnswerView
    {
        [Required]
        public string Rep { get; set; }
        [Required]
        public int Repchosen { get; set; }
        public int Dest { get; set; }
        public int Id_message { get; set; }
        public string Subject { get; set; }
        public string Actualurl { get; set; }
        public Notification_Simple Not { get; set; }
        public AnswerView Init(Notification_Simple notif)
        {
            var ret = new AnswerView() { Not = notif };
            return ret;
        }
    }
}