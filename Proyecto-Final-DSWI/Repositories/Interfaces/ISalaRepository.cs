using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Repositories.Interfaces
{
    public interface ISalaRepository
    {
        public Salas buscarSala(int id);
        public IEnumerable<Salas> listarSalas();
        public string agregarSalas(Salas salas);
        public string actualizarSala(Salas salas);
        public string eliminarSala(int id);
    }
}
