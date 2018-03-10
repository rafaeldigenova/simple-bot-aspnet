using SimpleBot.Infra;

namespace SimpleBot
{
    public class Message : EntidadeBase
    {
        public string UserId { get; set; }
        public string User { get; set; }
        public string Text { get; set; }

        public Message(string userId, string username, string text)
            : base()
        {
            this.UserId = userId;
            this.User = username;
            this.Text = text;
        }
    }
}