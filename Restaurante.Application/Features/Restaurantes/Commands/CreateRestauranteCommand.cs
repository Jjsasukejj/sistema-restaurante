using MediatR;

namespace Restaurante.Application.Features.Restaurantes.Commands
{
    public class CreateRestauranteCommand : IRequest<int>
    {
        public string Nombre { get; set; } = default!;
        public string Direccion { get; set; } = default!;
    }
}
