using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace PersonagemApi.Data
{
    public class ConexaoBanco
    {
        private readonly string _connectionString;

        #region conexão

        public ConexaoBanco(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Unimed_Sorocaba")!;
        }

        public IDbConnection CreateConnection() => new OracleConnection(_connectionString);

        #endregion
    }
}
