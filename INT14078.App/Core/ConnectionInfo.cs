using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT14078.App.Core
{
    public class ConnectionInfo
    {
        public ConnectionInfo(string serverName, string userName, string password)
        {
            ServerName = serverName;
            UserName = userName;
            Password = password;
        }

        public string ServerName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string GetConectionString()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

            stringBuilder.DataSource = ServerName;
            stringBuilder.UserID = UserName;
            stringBuilder.Password = Password;

            return stringBuilder.ConnectionString;
        }

        public string GetConectionString(string serverName)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

            stringBuilder.DataSource = serverName;
            stringBuilder.TrustServerCertificate = true;

            return stringBuilder.ConnectionString;
            
        }
    }
}
