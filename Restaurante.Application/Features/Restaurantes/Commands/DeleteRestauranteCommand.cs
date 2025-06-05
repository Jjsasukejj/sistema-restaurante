using MediatR;

namespace Restaurante.Application.Features.Restaurantes.Commands
{
    public class DeleteRestauranteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
