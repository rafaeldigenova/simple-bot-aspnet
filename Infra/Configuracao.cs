using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot.Infra
{
    public class Configuracao
    {
        public static string ConnectionString
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
    }
}