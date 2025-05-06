using Microsoft.Data.SqlClient;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;

namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class listarPeliculasDAO : IListarPeliculas
    {
        private readonly string _cadena;

        public listarPeliculasDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
        }

        public IEnumerable<PeliculaList> listarPeliculas()
        {
            List<PeliculaList> list = new List<PeliculaList>();
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Peliculas_Select", cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PeliculaList p = new PeliculaList()
                        {
                            id_pelicula = reader.GetInt32(0),
                            nombre_pelicula = reader.GetString(1)
                        };

                        list.Add(p);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return list;
        }
    }
}
