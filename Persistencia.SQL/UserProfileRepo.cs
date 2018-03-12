using SimpleBot.Dominio;
using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot.Persistencia.SQL
{
    public class UserProfileRepo : IUserProfileRepo
    {
        private static string _connectionString;
        public UserProfileRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task SetAsync(UserProfile userProfile)
        {
            return Task.Run(() =>
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.Text;

                    var cmdText = new StringBuilder
                                      ("if exists (select * from UserProfile where UserId = @UserId)");
                    cmdText.AppendLine("update UserProfile set Visitas = @Visitas where UserId = @UserId");
                    cmdText.AppendLine("else");
                    cmdText.AppendLine("Insert Into UserProfile (UserId, Visitas) values (@UserId, @Visitas)");
                    cmdText.AppendLine("end");

                    cmd.CommandText = cmdText.ToString();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@UserId", userProfile.UserId);
                    cmd.Parameters.AddWithValue("@Visitas", userProfile.Visitas);
                    cmd.ExecuteNonQuery();
                }
            });
        }

        public Task<UserProfile> GetAsync(string userId)
        {
            return Task.Run(() =>
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
            });
        }
    }
}