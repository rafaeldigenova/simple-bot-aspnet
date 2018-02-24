using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class UserProfile : AggregateRoot
    {
        public string UserId { get; set; }

        public int Visitas { get; set; }

        public UserProfile(string userId, int visitas)
        {
            UserId = userId;
            Visitas = visitas;
        }
    }
}