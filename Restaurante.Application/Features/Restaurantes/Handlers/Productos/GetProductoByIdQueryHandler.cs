using Dapper;
using MediatR;
using Restaurante.Application.Features.Restaurantes.Queries.Productos;
using Restaurante.Application.Modelos;
using System.Data;

namespace Restaurante.Application.Features.Restaurantes.Handlers.Productos
{
    public class GetProductoByIdQueryHandler : IRequestHandler<GetProductoByIdQuery, ProductoModelo?>
    {
        private readonly IDbConnection _connection;

        public GetProductoByIdQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ProductoModelo?> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", request.Id);

            var result = await _connection.QueryFirstOrDefaultAsync<ProductoModelo>(
                "sp_ObtenerProductoPorId",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
