using System;
using System.Threading.Tasks;
using SimpleBot.Dominio;
using System.Linq;
using SimpleBot.Persistencia.MongoDB;

namespace SimpleBot.Persistencia.MongoDB
{
    public class UserProfileRepo : IUserProfileRepo
    {
        private static string _connectionString;

        private static MongoHelper<UserProfile> _mongoHelper;

        private static MongoHelper<UserProfile> MongoHelper
        {
            get
            {
                if(_mongoHelper == null)
                {
                    _mongoHelper = new MongoHelper<UserProfile>("UserProfile", _connectionString);
                }

                return _mongoHelper;
            }
        }

        public UserProfileRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<UserProfile> GetAsync(string userId)
        {
            return Task.Run(() =>
            {
                return MongoHelper.GetLazy().FirstOrDefault(x => x.UserId == userId);
            });
        }

        public Task SetAsync(UserProfile userProfile)
        {
            return Task.Run(async () =>
            {
                await MongoHelper.ReplaceOneAsync(x => x.UserId == userProfile.UserId, userProfile);
            });
        }
    }
}