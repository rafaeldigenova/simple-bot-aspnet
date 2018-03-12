using SimpleBot.Infra;
using System.Threading.Tasks;

namespace SimpleBot.Dominio
{
    public interface IMessageRepo
    {
        Task SalvarMensagemAsync(Message message);
    }
}