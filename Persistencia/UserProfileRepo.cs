using System;
using System.Collections.Generic;
using System.Linq;
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