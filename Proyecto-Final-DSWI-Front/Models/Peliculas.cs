using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_DSWI_Front.Models
{
    public class Peliculas
    {
        [Display(Name = "Id Pelicula")]
        public int id_pelicula { get; set; }

        [Display(Name = "Nombre  de la película")]
        public string nombre_pelicula { get; set; }

        [Display(Name = "Director de la película")]
        public string director_pelicula { get; set; }

        [Display(Name = "Género")]
        public string genero_pelicula { get; set; }

        [Display(Name = "Duración")]
        public int duracion_minutos { get; set; }

        [Display(Name = "Idioma")]
        public string idioma_pelicula { get; set; }

        [Display(Name = "Clasificación")]
        public string clasificacion_pelicula { get; set; }
    }
}
