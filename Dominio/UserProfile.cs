using SimpleBot.Infra;

namespace SimpleBot.Dominio
{
    public class UserProfile : EntidadeBase
    {
        public string UserId { get; set; }

        public int Visitas { get; set; }

        public UserProfile(string userId, int visitas)
        {
            UserId = userId;
            Visitas = visitas;
        }
    }
}