using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.Memoria
{
    public class UserProfileRepo : RepoBase<UserProfile>, IUserRepo
    {
        public UserProfileRepo()
            : base ("UserProfile")
        {

        }
    }
}