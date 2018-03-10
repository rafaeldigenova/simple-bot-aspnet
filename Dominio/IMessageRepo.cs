using SimpleBot.Infra;

namespace SimpleBot.Dominio
{
    public interface IMessageRepo
    {
        void SalvarMensagem(Message message);
    }
}