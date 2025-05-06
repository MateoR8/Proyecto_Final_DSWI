using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.DAO;

namespace Proyecto_Final_DSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : Controller
    {
        [HttpGet("listarPeliculas")]
        public async Task<ActionResult<List<Peliculas>>> listarPeliculas()
        {
            var lista = await Task.Run(() => new peliculaDAO().listarPeliculas());
            return Ok(lista);
        }

        [HttpPost("agregarPelicula")]
        public async Task<ActionResult<string>> agregarPelicula(Peliculas cli)
        {
            var mensaje = await Task.Run(() => new peliculaDAO().agregarPelicula(cli));
            return Ok(mensaje);
        }

        [HttpPost("actualizarPelicula")]
        public async Task<ActionResult<string>> actualizarPelicula(Peliculas cli)
        {
            var mensaje = await Task.Run(() => new peliculaDAO().actualizarPelicula(cli));
            return Ok(mensaje);
        }

        [HttpDelete("eliminarPelicula")]
        public async Task<ActionResult<string>> eliminarPelicula(int id)
        {
            var mensaje = await Task.Run(() => new peliculaDAO().eliminarPelicula(id));
            return Ok(mensaje);
        }

        [HttpGet("buscarPelicula")]
        public async Task<ActionResult<Peliculas>> buscarPelicula(int id)
        {
            var pelicula = await Task.Run(() => new peliculaDAO().buscarPelicula(id));
            return Ok(pelicula);
        }
    }
}
