using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_DSWI.Models
{
    public class Funciones
    {
        [Display(Name = "Id Funcion")]
        public int id_funcion { get; set; }

        [Display(Name = "Id Sala")]
        public int id_sala { get; set; }

        [Display(Name = "Codigo Sala")]
        public string? cod_sala { get; set; }

        [Display(Name = "Id Pelicula")]
        public int id_pelicula { get; set; }

        [Display(Name = "Nombre Peliculas")]
        public string? nombre_pelicula { get; set; }

        [Display(Name = "Fecha Funcion")]
        public DateOnly fecha_funcion { get; set; }

        [Display(Name = "Horario de Inicio")]
        public TimeOnly hora_inicio { get; set; }
    }
}