using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BagelBoss.DAL
{
    public class SqlServerDbConnectionProvider : IDbConnectionProvider
    {
        private readonly String locationName;
        private readonly String connectionString;

        public SqlServerDbConnectionProvider(String locationName)
        {
            this.locationName = locationName;

            var connectionStrings = ConfigurationManager.ConnectionStrings;
            var connectionString = connectionStrings[locationName];

            if (connectionString == null)
            {
                throw new Exception(String.Format("Unable to locate connection string for location {0}", locationName));
            }

            Debug.WriteLine(String.Format("Obtained a connection string for location {0}", locationName));
            this.connectionString = connectionString.ConnectionString;
        }

        public IDbConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
