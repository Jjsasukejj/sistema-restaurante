namespace Restaurante.Application.DTOs
{
    public class ProductoDto
    {
        /// <summary>
        /// Propiedad Nombre 
        /// </summary>
        public string? Nombre { get; set; }
        /// <summary>
        /// Propiedad Descripcion 
        /// </summary>
        public string? Descripcion { get; set; }
        /// <summary>
        /// Propiedad Precio 
        /// </summary>
        public decimal? Precio { get; set; }
        /// <summary>
        /// Propiedad Disponible 
        /// </summary>
        public bool? Disponible { get; set; }
    }
}
