using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Features.Restaurantes.Commands;
using Restaurante.Application.Features.Restaurantes.Queries;
using Restaurante.Application.Modelos;

namespace Restaurante.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ConsultarTodos")]
        public async Task<ActionResult<IEnumerable<RestauranteModelo>>> ConsultarTodos()
        {
            var result = await _mediator.Send(new GetAllRestaurantesQuery());
            return Ok(result);
        }

        [HttpPost("CrearRestaurante")]
        public async Task<IActionResult> CrearRestaurante([FromBody] CreateRestauranteCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(ConsultarTodos), new { id }, new { id });
        }

        [HttpPut("ActualizarRestaurante")]
        public async Task<IActionResult> ActualizarRestaurante([FromBody] UpdateRestauranteCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("EliminarRestaurante/{id}")]
        public async Task<IActionResult> EliminarRestaurante(int id)
        {
            await _mediator.Send(new DeleteRestauranteCommand { Id = id });
            return NoContent();
        }

        [HttpGet("ConsultarPorId/{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            var restaurante = await _mediator.Send(new GetRestauranteByIdQuery(id));
            if (restaurante == null)
                return NotFound();

            return Ok(restaurante);
        }
    }
}
