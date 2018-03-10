namespace SimpleBot.Persistencia.Memoria
{
    public class MessageRepo : RepoBase<Message>
    {
        public MessageRepo()
            : base("Messages")
        {

        }
    }
}