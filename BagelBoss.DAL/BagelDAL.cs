using System;
using System.Data.SqlClient;
using System.Diagnostics;
using BagelBoss.Contracts;

namespace BagelBoss.DAL
{
    public class BagelDAL : IBagelDAL
    {
        private const String CREATE_BAGEL_SQL = "INSERT INTO dbo.Bagels (Id, Toasted) VALUES (@Id, @Toasted)";

        private readonly IDbConnectionProvider dbConnectionProvider;

        public BagelDAL(IDbConnectionProvider dbConnectionProvider)
        {
            this.dbConnectionProvider = dbConnectionProvider;
        }

        public Bagel CreateBagel(Boolean toasted)
        {
            var bagel = new Bagel()
            {
                Id = Guid.NewGuid().ToString(),
                Toasted = toasted
            };

            using (var dbConnection = GetConnection())
            {
                using (var command = new SqlCommand(CREATE_BAGEL_SQL, dbConnection))
                {
                    command.Parameters.AddWithValue("@Id", bagel.Id);
                    command.Parameters.AddWithValue("@Toasted", bagel.Toasted);
#if DEBUG
                    Debug.WriteLine("Skipping the invocation of the query, compiled with DEBUG");
#else
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                    dbConnection.Close();
#endif
                }
            }

            return bagel;
        }

        private SqlConnection GetConnection()
        {
            return (SqlConnection)dbConnectionProvider.GetConnection();
        }
    }
}
