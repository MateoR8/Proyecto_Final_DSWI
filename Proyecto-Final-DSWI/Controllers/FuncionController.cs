using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.DAO;

namespace Proyecto_Final_DSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        [HttpGet("listarFunciones")]
        public async Task<ActionResult<List<Funciones>>> listarFunciones()
        {
            var lista = await Task.Run(() => new funcionDAO().listarFunciones());
            return Ok(lista);
        }

        [HttpGet("listarPeliculas")]
        public async Task<ActionResult<List<PeliculaList>>> listarPeliculas()
        {
            var lista = await Task.Run(() => new listarPeliculasDAO().listarPeliculas());
            return Ok(lista);
        }

        [HttpGet("listarSalas")]
        public async Task<ActionResult<List<SalaList>>> listarSalas()
        {
            var lista = await Task.Run(() => new listarSalasDAO().listarSalas());
            return Ok(lista);
        }

        [HttpPost("agregarFuncion")]
        public async Task<ActionResult<string>> agregarFuncion(Funciones fun)
        {
            var mensaje = await Task.Run(() => new funcionDAO().agregarFunciones(fun));
            return Ok(mensaje);
        }

        [HttpPost("actualizarFuncion")]
        public async Task<ActionResult<string>> actualizarFuncion(Funciones fun)
        {
            var mensaje = await Task.Run(() => new funcionDAO().actualizarFunciones(fun));
            return Ok(mensaje);
        }

        [HttpDelete("eliminarFuncion")]
        public async Task<ActionResult<string>> eliminarFuncion(int id)
        {
            var mensaje = await Task.Run(() => new funcionDAO().eliminarFunciones(id));
            return Ok(mensaje);
        }

        [HttpGet("buscarFuncion")]
        public async Task<ActionResult<Funciones>> buscarFuncion(int id)
        {
            var cliente = await Task.Run(() => new funcionDAO().buscarFuncion(id));
            return Ok(cliente);
        }
    }
}
