using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.DAO;

namespace Proyecto_Final_DSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DulceriaController : ControllerBase
    {
        [HttpGet("getProductos")]
        public async Task<ActionResult<List<Dulceria>>> getProductos()
        {
            var lista = await Task.Run(() => new dulceriaDAO().listarProductos());
            return Ok(lista);
        }

        [HttpPost("actualizarProducto")]
        public async Task<ActionResult<string>> actualizarProducto(Dulceria dul)
        {
            var mensaje = await Task.Run(() => new dulceriaDAO().actualizarProducto(dul));
            return Ok(mensaje);
        }

        [HttpPost("agregarProducto")]
        public async Task<ActionResult<string>> agregarProducto(Dulceria dul)
        {
            var mensaje = await Task.Run(() => new dulceriaDAO().agregarProducto(dul));
            return Ok(mensaje);
        }

        [HttpDelete("eliminarProducto")]
        public async Task<ActionResult<string>> eliminarProducto(int id)
        {
            var mensaje = await Task.Run(() => new dulceriaDAO().eliminarProducto(id));
            return Ok(mensaje);
        }

        [HttpGet("buscarProducto")]
        public async Task<ActionResult<Dulceria>> buscarProducto(int id)
        {
            var vendedor = await Task.Run(() => new dulceriaDAO().buscarProducto(id));
            return Ok(vendedor);
        }
    }
}
