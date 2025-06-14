using MediatR;
using Restaurante.Application.Modelos;

namespace Restaurante.Application.Features.Restaurantes.Queries.Productos
{
    public class GetProductoByIdQuery : IRequest<ProductoModelo>
    {
        public int Id { get; set; }

        public GetProductoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
