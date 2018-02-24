using System.Data;

namespace BagelBoss.DAL
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
