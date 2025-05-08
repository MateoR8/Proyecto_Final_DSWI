namespace Proyecto_Final_DSWI.Models
{
    public class LoginRequest
    {
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }
    }

    public class Admin
    {
        public int idAdmin { get; set; }
        public string nombre { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
    }
}
