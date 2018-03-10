namespace SimpleBot.Persistencia.Memoria
{
    public class UserProfileRepo : RepoBase<UserProfile>
    {
        public UserProfileRepo()
            : base ("UserProfile")
        {

        }
    }
}