using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.Memoria
{
    public class MessageRepo : RepoBase<Message>, IMessageRepo
    {
        public MessageRepo()
            : base("Messages")
        {

        }
    }
}