using MediatR;

namespace Restaurante.Application.Features.Restaurantes.Commands.Productos
{
    public class CreateProductosCommand : IRequest<int>
    {
        public string? Nombre { get; set; } = default!;

        public string? Descripcion { get; set; } = default!;

        public decimal? Precio { get; set; }

        public bool? Disponible { get; set; }

        public int IdRestaurante { get; set; }
    }
}
