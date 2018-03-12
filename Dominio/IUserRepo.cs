using SimpleBot.Infra;
using System.Threading.Tasks;

namespace SimpleBot.Dominio
{
    public interface IUserProfileRepo
    {
        Task SetAsync(UserProfile userProfile);
        Task<UserProfile> GetAsync(string userId);
    }
}