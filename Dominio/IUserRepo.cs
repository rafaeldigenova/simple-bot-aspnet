using SimpleBot.Infra;
using System.Threading.Tasks;

namespace SimpleBot.Dominio
{
    public interface IUserProfileRepo
    {
        Task Set(UserProfile userProfile);
        Task<UserProfile> Get(string userId);
    }
}