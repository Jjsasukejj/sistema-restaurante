using Dapper;
using MediatR;
using Restaurante.Application.Features.Restaurantes.Commands;
using System.Data;

namespace Restaurante.Application.Features.Restaurantes.Handlers
{
    public class CreateRestauranteCommandHandler : IRequestHandler<CreateRestauranteCommand, int>
    {
        private readonly IDbConnection connection;

        public CreateRestauranteCommandHandler(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<int> Handle(CreateRestauranteCommand request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", request.Nombre);
            parameters.Add("@Direccion", request.Direccion);

            var id = await connection.ExecuteScalarAsync<int>(
                "sp_InsertarRestaurante",
                parameters,
                commandType: CommandType.StoredProcedure);

            return id;
        }
    }
}
