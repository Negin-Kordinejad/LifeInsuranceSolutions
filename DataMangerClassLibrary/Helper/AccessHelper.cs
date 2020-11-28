using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMangerClassLibrary.Helper
{
   public class AccessHelper
    {
        private static string serverName, databaseName, userId, password;
        public static string ConnectionString { get; set; }

        public static void Initialize(string connectionString)
        {
            SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder(connectionString);
            bool change = serverName != cb.DataSource || databaseName != cb.InitialCatalog || userId != cb.UserID || password != cb.Password;

            serverName = cb.DataSource;
            databaseName = cb.InitialCatalog;
            userId = cb.UserID;
            password = cb.Password;
            if (change)
                ConnectionString = connectionString;
        }
    }
}
