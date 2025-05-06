using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_DSWI.Models
{
    public class Peliculas
    {
        [Display(Name = "Id Pelicula")]
        public int id_pelicula { get; set; }

        [Display(Name = "Nombre Pelicula")]
        public string nombre_pelicula { get; set; }

        [Display(Name = "Director de la Pelicula")]
        public string director_pelicula { get; set; }

        [Display(Name = "Genero Pelicula")]
        public string genero_pelicula { get; set; }

        [Display(Name = "Duracion")]
        public int duracion_minutos { get; set; }

        [Display(Name = "Idioma")]
        public string idioma_pelicula { get; set; }

        [Display(Name = "Clasificacion")]
        public string clasificacion_pelicula { get; set; }
    }
}
