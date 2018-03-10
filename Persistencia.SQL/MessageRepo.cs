using SimpleBot.Dominio;
using SimpleBot.Infra;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleBot.Persistencia.SQL
{
    public class MessageRepo : RepoBase<Message>, IMessageRepo
    {
        private static string _connectionString;

        public MessageRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override async Task InsertOne(Message userProfile)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(_connectionString);
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into Messages ([User], UserId, Text) values (@User, @UserId, @Text)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@User", userProfile.User);
                cmd.Parameters.AddWithValue("@UserId", userProfile.UserId);
                cmd.Parameters.AddWithValue("@Text", userProfile.Text);
                cmd.ExecuteNonQuery();
            }
        }

        public override IQueryable<Message> GetLazy()
        {
            throw new NotImplementedException();
        }

        public override async Task ReplaceOne(Expression<Func<Message, bool>> filter,
            Message entity)
        {
            throw new NotImplementedException();
        }
    }
}