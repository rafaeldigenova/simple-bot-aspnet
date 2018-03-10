using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.MongoDB
{
    public class UserProfileRepo : RepoBase<UserProfile>, IUserRepo
    {
        public UserProfileRepo(string connectionString)
            : base ("UserProfile", connectionString)
        {

        }
    }
}