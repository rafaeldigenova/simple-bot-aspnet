using System.Configuration;

namespace SimpleBot.Infra
{
    public class Configuracao
    {
        public static string ConnectionStringMongoDB
        {
            get
            {
                return ConfigurationManager.AppSettings["mongoConn"];
            }
        }

        public static string ConnectionStringSql
        {
            get
            {
                return ConfigurationManager.AppSettings["sqlConn"];
            }
        }

        public static string DatabaseName
        {
            get
            {
                return ConfigurationManager.AppSettings["databaseName"];
            }
        }

        public static string DatabaseProvider
        {
            get
            {
                return ConfigurationManager.AppSettings["databasProvider"];
            }
        }
    }
}