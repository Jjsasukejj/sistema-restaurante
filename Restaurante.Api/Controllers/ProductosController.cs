using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Features.Restaurantes.Commands.Productos;
using Restaurante.Application.Features.Restaurantes.Queries.Productos;
using Restaurante.Application.Modelos;

namespace Restaurante.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CrearProducto")]
        public async Task<IActionResult> CrearProducto([FromBody] CreateProductosCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { mensaje = "Producto creado con éxito" });
        }

        [HttpGet("ConsultarTodos")]
        public async Task<ActionResult<IEnumerable<ProductoModelo>>> ConsultarTodos()
        {
            var result = await _mediator.Send(new GetAllProductosQuery());
            return Ok(result);
        }

        [HttpGet("ConsultarPorId/{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            var producto = await _mediator.Send(new GetProductoByIdQuery(id));
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }
    }
}
