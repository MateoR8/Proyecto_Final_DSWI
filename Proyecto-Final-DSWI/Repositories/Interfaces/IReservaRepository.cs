using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        public IEnumerable<Reservas> listarReservas();
        public IEnumerable<Reservas> listarReservasConFiltro(ReservaFiltros filtro);

    }
}
