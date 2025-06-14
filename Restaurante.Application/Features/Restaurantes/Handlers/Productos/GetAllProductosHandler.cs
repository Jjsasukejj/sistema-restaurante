using Dapper;
using MediatR;
using Restaurante.Application.Features.Restaurantes.Queries.Productos;
using Restaurante.Application.Modelos;
using Restaurante.Domain.Data;

namespace Restaurante.Application.Features.Restaurantes.Handlers.Productos
{
    public class GetAllProductosHandler : IRequestHandler<GetAllProductosQuery, IEnumerable<ProductoModelo>>
    {
        private readonly IConnectionFactory _connectionFactory;

        public GetAllProductosHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<ProductoModelo>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<ProductoModelo>(
                "sp_ObtenerProductos",
                commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }
    }
}
