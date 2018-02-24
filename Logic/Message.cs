using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class Message : AggregateRoot
    {
        public string UserId { get; set; }
        public string User { get; set; }
        public string Text { get; set; }

        public Message(string userId, string username, string text)
            : base()
        {
            this.UserId = userId;
            this.User = username;
            this.Text = text;
        }
    }
}