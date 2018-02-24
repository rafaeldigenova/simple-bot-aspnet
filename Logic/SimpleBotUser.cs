using SimpleBot.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        static Dictionary<string, UserProfile> _perfil = new Dictionary<string, UserProfile>();

        private static UserProfileRepo _userProfileRepo;

        private static UserProfileRepo UserProfileRepo
        {
            get
            {
                if(_userProfileRepo == null)
                {
                    _userProfileRepo = new UserProfileRepo();
                }
                return _userProfileRepo;
            }
        }

        public static async Task<string> Reply(Message message)
        {
            string userId = message.UserId;

            await IncreaseVisitis(userId);

            return $"{message.User} disse '{message.Text}'";
        }

        private static async Task<UserProfile> GetProfile(string id)
        {
            var userProfile = UserProfileRepo.GetLazy().Where(x => x.UserId == id).FirstOrDefault();

            if(userProfile == null)
            {
                userProfile = new UserProfile(id, 0);
                await SetProfile(userProfile);
            }

            return userProfile;
        }

        private static async Task SetProfile(UserProfile profile)
        {
           await UserProfileRepo.InsertOne(profile);
        }

        public static async Task IncreaseVisitis (string id)
        {
            var profile = await GetProfile(id);

            await UserProfileRepo.Increment(x => x.UserId == id,
                "Visitas", 1);
        }
    }
}