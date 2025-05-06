using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_DSWI_Front.Models
{
    public class Salas
    {
        [Display(Name = "Id Sala")]
        public int id_sala { get; set; }

        [Display(Name = "Codigo de la Sala")]
        public string cod_sala { get; set; }

        [Display(Name = "Capacidad de la Sala")]
        public int capacidad_sala { get; set; }
    }
}
