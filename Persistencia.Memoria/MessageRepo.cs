using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.Memoria
{
    public class MessageRepo : MemoHelper<Message>, IMessageRepo
    {
        public MessageRepo()
            : base("Messages")
        {

        }

        public void SalvarMensagem()
        {
            throw new System.NotImplementedException();
        }
    }
}