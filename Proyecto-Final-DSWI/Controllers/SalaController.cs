using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.DAO;

namespace Proyecto_Final_DSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        [HttpGet("getSalas")]
        public async Task<ActionResult<List<Salas>>> getSalas()
        {
            var lista = await Task.Run(() => new salaDAO().listarSalas());
            return Ok(lista);
        }

        [HttpPost("actualizarSala")]
        public async Task<ActionResult<string>> actualizarProducto(Salas sal)
        {
            var mensaje = await Task.Run(() => new salaDAO().actualizarSala(sal));
            return Ok(mensaje);
        }

        [HttpPost("agregarSala")]
        public async Task<ActionResult<string>> agregarProducto(Salas sal)
        {
            var mensaje = await Task.Run(() => new salaDAO().agregarSalas(sal));
            return Ok(mensaje);
        }

        [HttpDelete("eliminarSala")]
        public async Task<ActionResult<string>> eliminarProducto(int id)
        {
            var mensaje = await Task.Run(() => new salaDAO().eliminarSala(id));
            return Ok(mensaje);
        }

        [HttpGet("buscarSala")]
        public async Task<ActionResult<Salas>> buscarProducto(int id)
        {
            var vendedor = await Task.Run(() => new salaDAO().buscarSala(id));
            return Ok(vendedor);
        }
    }
}
