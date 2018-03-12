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

        private static IUserProfileRepo _userProfileRepo;

        private static IUserProfileRepo UserProfileRepo
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

        public static async Task<string> ReplyAsync(Message message)
        {
            try
            {
                string userId = message.UserId;

                var userProfile = await GetUserProfile(userId);

                userProfile.Visitas += 1;

                await UserProfileRepo.SetAsync(userProfile);

                return $"{message.User} conversou {userProfile.Visitas} vezes";
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private static async Task<UserProfile> GetUserProfile(string id)
        {
            var userProfile = await UserProfileRepo.GetAsync(id);

            if(userProfile == null)
            {
                userProfile = new UserProfile(id, 0);
                await UserProfileRepo.SetAsync(userProfile);
            }

            return userProfile;
        }
    }
}