using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Repositories.Interfaces
{
    public interface IDulceriaRepository
    {
        public Dulceria buscarProducto(int id);
        public IEnumerable<Dulceria> listarProductos();
        public string agregarProducto(Dulceria dulceria);
        public string actualizarProducto(Dulceria dulceria);
        public string eliminarProducto(int id);
    }
}
