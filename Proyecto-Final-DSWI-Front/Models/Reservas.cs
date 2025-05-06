using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_DSWI_Front.Models
{
    public class Reservas
    {
        [Display(Name = "Id Reserva")]
        public int idReserva { get; set; }

        [Display(Name = "Fecha de reserva")]
        public DateOnly fechaReserva { get; set; }

        [Display(Name = "Nombre del cliente")]
        public string nombreCliente { get; set; }

        [Display(Name = "Apellido paterno")]
        public string apellidoPatCliente { get; set; }

        [Display(Name = "Apellido materno")]
        public string apellidoMatCliente { get; set; }

        [Display(Name = "Correo")]
        public string correoCliente { get; set; }

        [Display(Name = "Fecha de función")]
        public DateOnly fechaFuncion { get; set; }

        [Display(Name = "Nombre película")]
        public string nombrePelicula { get; set; }

        [Display(Name = "Género")]
        public string generoPelicula { get; set; }

        [Display(Name = "Clasificación")]
        public string clasifPelicula { get; set; }

        [Display(Name = "Sala")]
        public string sala { get; set; }

        [Display(Name = "Producto")]
        public string producto { get; set; }
    }
}