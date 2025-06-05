using System.Data;

namespace Restaurante.Domain.Data
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
