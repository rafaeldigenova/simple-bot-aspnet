using System;
using System.Threading.Tasks;
using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.MongoDB
{
    public class MessageRepo : RepoBase<Message>, IMessageRepo
    {
        public MessageRepo(string connectionString)
            : base("Messages", connectionString)
        {
        }

        public async Task SalvarMensagem(Message message)
        {
            await ReplaceOne(x => x.Id == message.Id, message);
        }
    }
}