namespace Proyecto_Final_DSWI.Models
{
    public class ReservaFiltros
    {
        public DateOnly? fechaReserva { get; set; }
        public string? nombresCliente { get; set; }
        public string? apePaterno { get; set; }
        public string? apeMaterno { get; set; }
        public DateOnly? fechaFuncion { get; set; }
        public string? nombrePelicula { get; set; }
        public string? codigoSala { get; set; }
    }
}
