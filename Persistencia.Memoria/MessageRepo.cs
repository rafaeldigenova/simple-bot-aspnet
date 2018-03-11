using System;
using System.Threading.Tasks;
using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.Memoria
{
    public class MessageRepo : MemoHelper<Message>, IMessageRepo
    {
        public MessageRepo()
        {
        }

        public async Task SalvarMensagem(Message message)
        {
            await ReplaceOne(x => x.Id == message.Id, message);
        }
    }
}