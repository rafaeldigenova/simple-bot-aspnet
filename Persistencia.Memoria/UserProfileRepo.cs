using System;
using System.Threading.Tasks;
using SimpleBot.Dominio;
using System.Linq;

namespace SimpleBot.Persistencia.Memoria
{
    public class UserProfileRepo : IUserProfileRepo
    {
        private static string _connectionString;

        private static MemoHelper<UserProfile> _memoHelper;

        private static MemoHelper<UserProfile> MemoHelper
        {
            get
            {
                if (_memoHelper == null)
                {
                    _memoHelper = new MemoHelper<UserProfile>();
                }

                return _memoHelper;
            }
        }

        public Task<UserProfile> GetAsync(string userId)
        {
            return Task.Run(() =>
            {
                return MemoHelper.GetLazy().FirstOrDefault(x => x.UserId == userId);
            });
        }

        public Task SetAsync(UserProfile userProfile)
        {
            return MemoHelper.ReplaceOneAsync(x => x.UserId == userProfile.UserId, userProfile);
        }
    }
}