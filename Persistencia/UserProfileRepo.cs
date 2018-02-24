﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace SimpleBot.Persistencia
{
    public class UserProfileRepo : RepoBase<UserProfile>
    {
        public UserProfileRepo()
            : base ("UserProfile")
        {

        }
    }
}