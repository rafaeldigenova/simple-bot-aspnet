using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class Message : AggregateRoot
    {
        public string User { get; set; }
        public string Text { get; set; }

        public Message(string id, string username, string text)
        {
            this.Id = id;
            this.User = username;
            this.Text = text;
        }
    }
}