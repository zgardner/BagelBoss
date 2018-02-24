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

        public SqlServerDbConnectionProvider(String locationName)
        {
            this.locationName = locationName;
        }

        public IDbConnection GetConnection()
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings;
            var connectionString = connectionStrings[locationName];

            if (connectionString == null)
            {
                throw new Exception(String.Format("Unable to locate connection string for location {0}", locationName));
            }

            Debug.WriteLine(String.Format("Obtained a connection string for location {0}", locationName));

            var connection = new SqlConnection(connectionString.ConnectionString);

            return connection;
        }
    }
}
