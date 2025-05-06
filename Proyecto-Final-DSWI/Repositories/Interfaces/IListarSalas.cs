using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Repositories.Interfaces
{
    public interface IListarSalas
    {
        public IEnumerable<SalaList> listarSalas();
    }
}
