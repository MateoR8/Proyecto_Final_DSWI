using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_DSWI.Models
{
    public class Dulceria
    {
        [Display(Name = "Id Producto")]
        public int id_producto { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string nombre_producto { get; set; }

        [Display(Name = "Precio del Producto")]
        public decimal precio_producto { get; set; }

        [Display(Name = "Marca del Producto")]
        public string marca_producto { get; set; }
    }
}
