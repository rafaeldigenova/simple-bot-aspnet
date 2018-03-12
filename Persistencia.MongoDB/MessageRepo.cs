using System;
using System.Threading.Tasks;
using SimpleBot.Dominio;

namespace SimpleBot.Persistencia.MongoDB
{
    public class MessageRepo : IMessageRepo
    {
        private static string _connectionString;

        private static MongoHelper<Message> _mongoHelper;

        private static MongoHelper<Message> MongoHelper
        {
            get
            {
                if (_mongoHelper == null)
                {
                    _mongoHelper = new MongoHelper<Message>("Messages", _connectionString);
                }

                return _mongoHelper;
            }
        }

        public MessageRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task SalvarMensagemAsync(Message message)
        {
            await MongoHelper.ReplaceOneAsync(x => x.Id == message.Id, message);
        }
    }
}