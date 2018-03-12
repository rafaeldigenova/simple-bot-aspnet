using System;
using System.Threading.Tasks;
using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.Memoria
{
    public class MessageRepo : IMessageRepo
    {
        private static string _connectionString;

        private static MemoHelper<Message> _memoHelper;

        private static MemoHelper<Message> MemoHelper
        {
            get
            {
                if (_memoHelper == null)
                {
                    _memoHelper = new MemoHelper<Message>();
                }

                return _memoHelper;
            }
        }
        
        public async Task SalvarMensagemAsync(Message message)
        {
            await MemoHelper.ReplaceOneAsync(x => x.Id == message.Id, message);
        }
    }
}