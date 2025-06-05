using Dapper;
using MediatR;
using Restaurante.Application.Features.Restaurantes.Commands;
using System.Data;

namespace Restaurante.Application.Features.Restaurantes.Handlers
{
    public class UpdateRestauranteCommandHandler : IRequestHandler<UpdateRestauranteCommand, Unit>
    {
        private readonly IDbConnection _connection;

        public UpdateRestauranteCommandHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Unit> Handle(UpdateRestauranteCommand request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", request.Id);
            parameters.Add("@Nombre", request.Nombre);
            parameters.Add("@Direccion", request.Direccion);

            await _connection.ExecuteAsync(
                "sp_ActualizarRestaurante",
                parameters,
                commandType: CommandType.StoredProcedure);

            return Unit.Value;
        }
    }
}
