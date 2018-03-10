namespace SimpleBot.Persistencia
{
    public class MessageRepo : RepoBase<Message>
    {
        public MessageRepo()
            : base("Messages")
        {
        }
    }
}