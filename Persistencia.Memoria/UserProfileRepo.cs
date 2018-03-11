using System;
using System.Threading.Tasks;
using SimpleBot.Dominio;
using System.Linq;

namespace SimpleBot.Persistencia.Memoria
{
    public class UserProfileRepo : MemoHelper<UserProfile>, IUserProfileRepo
    {
        public UserProfileRepo()
        {

        }

        public Task<UserProfile> Get(string userId)
        {
            return Task.Run(() =>
            {
                return GetLazy().FirstOrDefault(x => x.UserId == userId);
            });
        }

        public Task Set(UserProfile userProfile)
        {
            return ReplaceOne(x => x.UserId == userProfile.UserId, userProfile);
        }
    }
}