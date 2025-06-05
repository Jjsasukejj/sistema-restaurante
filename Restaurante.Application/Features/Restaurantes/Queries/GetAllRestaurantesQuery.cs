using MediatR;
using Restaurante.Application.DTOs;

namespace Restaurante.Application.Features.Restaurantes.Queries
{
    public class GetAllRestaurantesQuery : IRequest<IEnumerable<RestauranteDto>> { }
}
