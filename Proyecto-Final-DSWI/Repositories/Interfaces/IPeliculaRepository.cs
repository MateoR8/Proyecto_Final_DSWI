using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Repositories.Interfaces
{
    public interface IPeliculaRepository
    {
        public Peliculas buscarPelicula(int id);
        public IEnumerable<Peliculas> listarPeliculas();
        public string agregarPelicula(Peliculas pelicula);
        public string actualizarPelicula(Peliculas pelicula);
        public string eliminarPelicula(int id);
    }
}
