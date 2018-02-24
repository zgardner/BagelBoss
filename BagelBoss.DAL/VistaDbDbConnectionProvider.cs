using System;
using System.Data;

namespace BagelBoss.DAL
{
    public class VistaDbDbConnectionProvider : IDbConnectionProvider
    {
        public IDbConnection GetConnection()
        {
            throw new Exception("VistaDB connection not yet implemented");
        }
    }
}
