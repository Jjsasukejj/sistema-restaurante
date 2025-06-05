using Dapper;
using MediatR;
using Restaurante.Application.Features.Restaurantes.Commands;
using System.Data;

namespace Restaurante.Application.Features.Restaurantes.Handlers
{
    public class DeleteRestauranteCommandHandler : IRequestHandler<DeleteRestauranteCommand, Unit>
    {
        private readonly IDbConnection _connection;

        public DeleteRestauranteCommandHandler(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<Unit> Handle(DeleteRestauranteCommand request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", request.Id);

            await _connection.ExecuteAsync(
                "sp_EliminarRestaurante",
                parameters,
                commandType: CommandType.StoredProcedure);

            return Unit.Value;
        }
    }
}
