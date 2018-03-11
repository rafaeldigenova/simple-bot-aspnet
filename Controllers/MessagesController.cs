using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using SimpleBot.Dominio;
using SimpleBot.Infra;
using SimpleBot.Logic;
using SimpleBot.Persistencia.SQL;


namespace SimpleBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private static IMessageRepo _messageRepo;

        private static IMessageRepo MessageRepo
        {
            get
            {
                if (_messageRepo == null)
                {
                    _messageRepo = PersistencyFactory.ObterRepositorioDeMensagem();
                }
                return _messageRepo;
            }
        }

        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity != null && activity.Type == ActivityTypes.Message)
            {
                await HandleActivityAsync(activity);
            }

            // HTTP 202
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        // Estabelece comunicação entre o usuário e o SimpleBotUser
        async Task HandleActivityAsync(Activity activity)
        {
            string text = activity.Text;
            string userFromId = activity.From.Id;
            string userFromName = activity.From.Name;

            var message = new Message(userFromId, userFromName, text);

            string response = await SimpleBotUser.Reply(message);

            var tasks = new Task[]
            {
                MessageRepo.SalvarMensagem(message),
                ReplyUserAsync(activity, response)
            };

            Task.WaitAll(tasks);
        }

        // Responde mensagens usando o Bot Framework Connector
        async Task ReplyUserAsync(Activity message, string text)
        {
            var connector = new ConnectorClient(new Uri(message.ServiceUrl));
            var reply = message.CreateReply(text);

            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}