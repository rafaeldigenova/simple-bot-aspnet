using SimpleBot.Dominio;
using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleBot.Persistencia.SQL
{
    public class UserProfileRepo : IUserRepo
    {
        private static string _connectionString;
        public UserProfileRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Set(UserProfile userProfile)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into UserProfile (UserId, Visitas) values (@UserId, @Visitas)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserId", userProfile.UserId);
                cmd.Parameters.AddWithValue("@Visitas", userProfile.Visitas);
                cmd.ExecuteNonQuery();
            }
        }

        public UserProfile Get(string userId)
        {
            var resultado = new List<UserProfile>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select UserId, Visitas from UserProfile where UserId = @UserId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserId", userId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultado.Add(new UserProfile(
                        (string)reader["UserId"],
                        (int)reader["Visitas"]));
                }
            }

            return resultado.FirstOrDefault();
        }

    }
}