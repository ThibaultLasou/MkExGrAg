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
        public string rep { get; set; }
        [Required]
        public int repchosen { get; set; }
        public int dest { get; set; }
        public int id_message { get; set; }
        public string subject { get; set; }
        public string actualurl { get; set; }
        public Notification_Simple not { get; set; }
        public AnswerView Init(Notification_Simple notif)
        {
            var ret = new AnswerView() { not = notif };
            return ret;
        }
    }
}