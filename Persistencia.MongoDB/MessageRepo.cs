using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.MongoDB
{
    public class MessageRepo : RepoBase<Message>, IMessageRepo
    {
        public MessageRepo(string connectionString)
            : base("Messages", connectionString)
        {
        }
    }
}