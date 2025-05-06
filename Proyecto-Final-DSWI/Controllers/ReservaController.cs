using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.DAO;

namespace Proyecto_Final_DSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        [HttpGet("listarReservas")]
        public async Task<ActionResult<List<Reservas>>> listarReservas()
        {
            var lista = await Task.Run(() => new reservaDAO().listarReservas());
            return Ok(lista);
        }

        [HttpPost("listarConFiltros")]
        public IActionResult listarReservasConFiltros([FromBody] ReservaFiltros filtros)
        {
            try
            {
                var lista = new reservaDAO().listarReservasConFiltro(filtros);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las reservas: {ex.Message}");
            }
        }
    }
}
