namespace Restaurante.Application.Modelos
{
    public class ProductoModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public int IdRestaurante { get; set; }
    }
}
