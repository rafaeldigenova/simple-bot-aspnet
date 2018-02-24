using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Persistencia.Memoria
{
    public class MessageRepo : RepoBase<Message>
    {
        public MessageRepo()
            : base("Messages")
        {

        }
    }
}