using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace CharacterApi.Data
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        #region connection

        public DatabaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Unimed_Sorocaba")!;
        }

        public IDbConnection CreateConnection() => new OracleConnection(_connectionString);

        #endregion
    }
}
