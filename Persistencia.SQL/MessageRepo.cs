using SimpleBot.Dominio;
using SimpleBot.Infra;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleBot.Persistencia.SQL
{
    public class MessageRepo : IMessageRepo
    {
        private static string _connectionString;

        public MessageRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SalvarMensagem(Message message)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(_connectionString);
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into Messages ([User], UserId, Text) values (@User, @UserId, @Text)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@User", message.User);
                cmd.Parameters.AddWithValue("@UserId", message.UserId);
                cmd.Parameters.AddWithValue("@Text", message.Text);
                cmd.ExecuteNonQuery();
            }
        }
    }
}