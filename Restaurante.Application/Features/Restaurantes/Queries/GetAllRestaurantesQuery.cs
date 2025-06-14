using MediatR;
using Restaurante.Application.Modelos;

namespace Restaurante.Application.Features.Restaurantes.Queries
{
    public class GetAllRestaurantesQuery : IRequest<IEnumerable<RestauranteModelo>> { }
}
