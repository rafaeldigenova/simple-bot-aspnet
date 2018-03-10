using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.Memoria
{
    public class UserProfileRepo : MemoHelper<UserProfile>, IUserRepo
    {
        public UserProfileRepo()
            : base ("UserProfile")
        {

        }

        public UserProfile Get()
        {
            throw new System.NotImplementedException();
        }

        public void SalvarHistorico()
        {
            throw new System.NotImplementedException();
        }

        public void Set(UserProfile userProfile)
        {
            throw new System.NotImplementedException();
        }
    }
}