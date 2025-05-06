using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.DAO;

namespace Proyecto_Final_DSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("listarClientes")]
        public async Task<ActionResult<List<Clientes>>> listarClientes()
        {
            var lista = await Task.Run(() => new clienteDAO().listarClientes());
            return Ok(lista);
        }

        [HttpPost("agregarCliente")]
        public async Task<ActionResult<string>> agregarCliente(Clientes cli)
        {
            var mensaje = await Task.Run(() => new clienteDAO().agregarCliente(cli));
            return Ok(mensaje);
        }

        [HttpPost("actualizarCliente")]
        public async Task<ActionResult<string>> actualizarCliente(Clientes cli)
        {
            var mensaje = await Task.Run(() => new clienteDAO().actualizarCliente(cli));
            return Ok(mensaje);
        }

        [HttpDelete("eliminarCliente")]
        public async Task<ActionResult<string>> eliminarCliente(int id)
        {
            var mensaje = await Task.Run(() => new clienteDAO().eliminarCliente(id));
            return Ok(mensaje);
        }

        [HttpGet("buscarCliente")]
        public async Task<ActionResult<Clientes>> buscarCliente(int id)
        {
            var cliente = await Task.Run(() => new clienteDAO().buscarCliente(id));
            return Ok(cliente);
        }
    }
}
