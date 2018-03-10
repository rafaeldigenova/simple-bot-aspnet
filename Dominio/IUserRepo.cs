using SimpleBot.Infra;
using System.Threading.Tasks;

namespace SimpleBot.Dominio
{
    public interface IUserRepo
    {
        Task Set(UserProfile userProfile);
        UserProfile Get(string userId);
    }
}