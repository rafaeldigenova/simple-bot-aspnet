using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace SimpleBot.Persistencia.SQL
{
    public class MessageRepo : RepoBase<Message>
    {
        public MessageRepo()
        {

        }

        public override async Task InsertOne(Message userProfile)
        {
            using (var connection = new SqlConnection(Configuracao.ConnectionStringSql))
            {
                connection.Open();
                var cmd = new SqlCommand(Configuracao.ConnectionStringSql);
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