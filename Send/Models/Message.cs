using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Send.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public string IdSender { get; set; }
        public string IdGetter { get; set; }
    }
}