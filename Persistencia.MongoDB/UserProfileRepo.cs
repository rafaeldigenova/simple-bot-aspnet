using System;
using System.Threading.Tasks;
using SimpleBot.Dominio;
using System.Linq;

namespace SimpleBot.Persistencia.MongoDB
{
    public class UserProfileRepo : RepoBase<UserProfile>, IUserProfileRepo
    {
        public UserProfileRepo(string connectionString)
            : base ("UserProfile", connectionString)
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
            return Task.Run(async () =>
            {
                await ReplaceOne(x => x.UserId == userProfile.UserId, userProfile);
            });
        }
    }
}