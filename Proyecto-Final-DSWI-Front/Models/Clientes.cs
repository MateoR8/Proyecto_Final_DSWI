using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_DSWI_Front.Models
{
    public class Clientes
    {
        [Display(Name = "Id Cliente")]
        public int id_cliente { get; set; }

        [Display(Name = "Dni Cliente")]
        public string dni_cliente { get; set; }

        [Display(Name = "Nombres del Cliente")]
        public string nombres_cliente { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string apellido_pat_cliente { get; set; }

        [Display(Name = "Apellido Materno")]
        public string apellido_mat_cliente { get; set; }

        [Display(Name = "Numero de Celular")]
        public string num_celular_cliente { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly fecha_nac_cliente { get; set; }

        [Display(Name = "Correo")]
        public string correo_cliente { get; set; }

    }
}
