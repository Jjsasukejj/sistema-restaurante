using MediatR;
using Restaurante.Application.Modelos;

namespace Restaurante.Application.Features.Restaurantes.Queries.Productos
{
    public class GetAllProductosQuery : IRequest<IEnumerable<ProductoModelo>> { }
}
