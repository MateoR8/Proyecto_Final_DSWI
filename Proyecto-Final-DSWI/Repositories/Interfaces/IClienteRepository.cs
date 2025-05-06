using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        public Clientes buscarCliente(int id);
        public IEnumerable<Clientes> listarClientes();
        public string agregarCliente(Clientes cliente);
        public string actualizarCliente(Clientes cliente);
        public string eliminarCliente(int id);
    }
}
