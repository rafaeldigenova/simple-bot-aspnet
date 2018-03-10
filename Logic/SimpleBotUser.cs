using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBot.Dominio;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        static Dictionary<string, UserProfile> _perfil = new Dictionary<string, UserProfile>();

        private static IUserRepo _userProfileRepo;

        private static IUserRepo UserProfileRepo
        {
            get
            {
                if(_userProfileRepo == null)
                {
                    _userProfileRepo = PersistencyFactory.ObterRepositorioDeUsuario();
                }
                return _userProfileRepo;
            }
        }

        public static async Task<string> Reply(Message message)
        {
            try
            {
                string userId = message.UserId;

                var userProfile = await GetProfile(userId);

                userProfile.Visitas += 1;

                await SetProfile(userProfile);

                return $"{message.User} conversou {userProfile.Visitas} vezes";
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private static async Task<UserProfile> GetProfile(string id)
        {
            var userProfile = UserProfileRepo.GetLazy().Where(x => x.UserId == id).FirstOrDefault();

            if(userProfile == null)
            {
                userProfile = new UserProfile(id, 0);
                await UserProfileRepo.InsertOne(userProfile);
            }

            return userProfile;
        }

        private static async Task SetProfile(UserProfile profile)
        {
           await UserProfileRepo.ReplaceOne(x => x.UserId == profile.UserId, profile);
        }
    }
}