using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class UserProfile : AggregateRoot
    {
        public int Visitas { get; set; }
    }
}