using MediatR;
using Restaurante.Application.Modelos;

namespace Restaurante.Application.Features.Restaurantes.Queries
{
    public class GetRestauranteByIdQuery : IRequest<RestauranteModelo>
    {
        public int Id { get; set; }
        public GetRestauranteByIdQuery(int id)
        {
            Id = id;
        }
    }
}
