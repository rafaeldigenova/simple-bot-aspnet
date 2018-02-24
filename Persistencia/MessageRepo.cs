using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Persistencia
{
    public class MessageRepo : RepoBase<Message>
    {
        public MessageRepo()
            : base("Messages")
        {

        }
    }
}