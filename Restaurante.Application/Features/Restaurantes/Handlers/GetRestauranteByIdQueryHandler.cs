using Dapper;
using MediatR;
using Restaurante.Application.DTOs;
using Restaurante.Application.Features.Restaurantes.Queries;
using System.Data;

namespace Restaurante.Application.Features.Restaurantes.Handlers
{
    public class GetRestauranteByIdQueryHandler : IRequestHandler<GetRestauranteByIdQuery, RestauranteDto?>
    {
        private readonly IDbConnection _connection;

        public GetRestauranteByIdQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<RestauranteDto?> Handle(GetRestauranteByIdQuery request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", request.Id);

            var restaurante = await _connection.QueryFirstOrDefaultAsync<RestauranteDto>(
                "sp_ObtenerRestaurantePorId",
                parameters,
                commandType: CommandType.StoredProcedure);

            return restaurante;
        }
    }
}
