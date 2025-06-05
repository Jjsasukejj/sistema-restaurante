using MediatR;

namespace Restaurante.Application.Features.Restaurantes.Commands
{
    public class UpdateRestauranteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Direccion { get; set; } = default!;
    }
}
