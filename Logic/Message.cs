using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class Message : AggregateRoot
    {
        public string Identificador { get; set; }
        public string User { get; set; }
        public string Text { get; set; }

        public Message(string identificador, string username, string text)
            : base()
        {
            this.Identificador = identificador;
            this.User = username;
            this.Text = text;
        }
    }
}