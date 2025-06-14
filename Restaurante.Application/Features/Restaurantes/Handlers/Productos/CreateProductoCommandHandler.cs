using Dapper;
using MediatR;
using Restaurante.Application.Features.Restaurantes.Commands.Productos;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurante.Application.Features.Restaurantes.Handlers.Productos
{
    public class CreateProductoCommandHandler : IRequestHandler<CreateProductosCommand, int>
    {
        private readonly IDbConnection connection;

        public CreateProductoCommandHandler(IDbConnection connection)
        {
            this.connection = connection;
        }
        public async Task<int> Handle(CreateProductosCommand request, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", request.Nombre);
            parameters.Add("@Descripcion", request.Descripcion);
            parameters.Add("@Precio", request.Precio);
            parameters.Add("@Disponible", request.Disponible);
            parameters.Add("@IdRestaurante", request.IdRestaurante);

            var id = await connection.ExecuteScalarAsync<int>(
                "sp_InsertarProducto",
                parameters,
                commandType: CommandType.StoredProcedure);

            return id;
        }
    }
}
