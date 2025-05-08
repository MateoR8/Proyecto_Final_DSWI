using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class authDAO : IAuthRepository
    {
        private readonly string _cadena;

        public authDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
        }


        public Admin loginAdmin(string username, string password)
        {
            Admin tempUser = new Admin();

            using (var connection = new SqlConnection(_cadena))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("sp_login", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", username);
                cmd.Parameters.AddWithValue("@contrasenia", password);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tempUser.idAdmin = reader.GetInt32(0);
                    tempUser.nombre = reader.GetString(1);
                    tempUser.apellidos = reader.GetString(2);
                    tempUser.email = reader.GetString(3);
                    tempUser.nombreUsuario = reader.GetString(4);
                }
                reader.Close();

                return tempUser;
            }

            return null;
        }
    }
}
