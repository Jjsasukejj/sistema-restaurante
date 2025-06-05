using Dapper;
using MediatR;
using Restaurante.Application.DTOs;
using Restaurante.Application.Features.Restaurantes.Queries;
using Restaurante.Domain.Data;

namespace Restaurante.Application.Features.Restaurantes.Handlers
{
    public class GetAllRestaurantesHandler : IRequestHandler<GetAllRestaurantesQuery, IEnumerable<RestauranteDto>>
    {
        private readonly IConnectionFactory _connectionFactory;

        public GetAllRestaurantesHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<RestauranteDto>> Handle(GetAllRestaurantesQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var result =
                await connection.QueryAsync<RestauranteDto>("sp_ObtenerRestaurantes", commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }
    }
}
