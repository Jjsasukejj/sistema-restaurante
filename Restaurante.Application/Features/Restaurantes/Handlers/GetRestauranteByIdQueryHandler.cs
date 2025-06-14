using Dapper;
using MediatR;
using Restaurante.Application.Features.Restaurantes.Queries;
using Restaurante.Application.Modelos;
using System.Data;

namespace Restaurante.Application.Features.Restaurantes.Handlers
{
    public class GetRestauranteByIdQueryHandler : IRequestHandler<GetRestauranteByIdQuery, RestauranteModelo?>
    {
        private readonly IDbConnection _connection;

        public GetRestauranteByIdQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<RestauranteModelo?> Handle(GetRestauranteByIdQuery request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", request.Id);

            var restaurante = await _connection.QueryFirstOrDefaultAsync<RestauranteModelo>(
                "sp_ObtenerRestaurantePorId",
                parameters,
                commandType: CommandType.StoredProcedure);

            return restaurante;
        }
    }
}
