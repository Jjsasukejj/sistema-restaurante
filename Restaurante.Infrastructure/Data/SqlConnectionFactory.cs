using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Restaurante.Domain.Data;
using System.Data;

namespace Restaurante.Infrastructure.Data
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Restaurante") ?? throw new ArgumentNullException("La cadena de conexión 'Restaurante' no está configurada.");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
