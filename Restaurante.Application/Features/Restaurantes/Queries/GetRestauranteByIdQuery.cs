using MediatR;
using Restaurante.Application.DTOs;

namespace Restaurante.Application.Features.Restaurantes.Queries
{
    public class GetRestauranteByIdQuery : IRequest<RestauranteDto>
    {
        public int Id { get; set; }
        public GetRestauranteByIdQuery(int id)
        {
            Id = id;
        }
    }
}
