using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Repositories.Interfaces
{
    public interface IFuncionRepository
    {
        public Funciones buscarFuncion(int id);
        public IEnumerable<Funciones> listarFunciones();
        public string agregarFunciones(Funciones funciones);
        public string actualizarFunciones(Funciones funciones);
        public string eliminarFunciones(int id);
    }
}
