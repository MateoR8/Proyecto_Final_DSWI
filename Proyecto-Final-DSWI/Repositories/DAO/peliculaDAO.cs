using Microsoft.Data.SqlClient;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;
using System.Data;

namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class peliculaDAO : IPeliculaRepository
    {
        private readonly string _cadena;

        public peliculaDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetConnectionString("DefaultConnection");
        }

        public string agregarPelicula(Peliculas pelicula)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Insertar_Pelicula", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE_PELICULA", pelicula.nombre_pelicula);
                    cmd.Parameters.AddWithValue("@DIRECTOR_PELI", pelicula.director_pelicula);
                    cmd.Parameters.AddWithValue("@GENERO_PELI", pelicula.genero_pelicula);
                    cmd.Parameters.AddWithValue("@DURACION_MINUTOS", pelicula.duracion_minutos);
                    cmd.Parameters.AddWithValue("@IDIOMA_PELI", pelicula.idioma_pelicula);
                    cmd.Parameters.AddWithValue("@CLASIFICACION_PELI", pelicula.clasificacion_pelicula);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se agregó {total} película(s)";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public string actualizarPelicula(Peliculas pelicula)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Actualizar_Pelicula", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PELICULA", pelicula.id_pelicula);
                    cmd.Parameters.AddWithValue("@NOMBRE_PELICULA", pelicula.nombre_pelicula);
                    cmd.Parameters.AddWithValue("@DIRECTOR_PELI", pelicula.director_pelicula);
                    cmd.Parameters.AddWithValue("@GENERO_PELI", pelicula.genero_pelicula);
                    cmd.Parameters.AddWithValue("@DURACION_MINUTOS", pelicula.duracion_minutos);
                    cmd.Parameters.AddWithValue("@IDIOMA_PELI", pelicula.idioma_pelicula);
                    cmd.Parameters.AddWithValue("@CLASIFICACION_PELI", pelicula.clasificacion_pelicula);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se actualizó {total} película(s)";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public string eliminarPelicula(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_Pelicula", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PELICULA", id);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se eliminó {total} película(s)";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public Peliculas buscarPelicula(int id)
        {
            return listarPeliculas().Where(p => p.id_pelicula == id).FirstOrDefault();
        }

        public IEnumerable<Peliculas> listarPeliculas()
        {
            List<Peliculas> lista = new List<Peliculas>();
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Listar_Peliculas", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Peliculas p = new Peliculas()
                        {
                            id_pelicula = dr.GetInt32(0),
                            nombre_pelicula = dr.GetString(1),
                            director_pelicula = dr.GetString(2),
                            genero_pelicula = dr.GetString(3),
                            duracion_minutos = dr.GetInt32(4),
                            idioma_pelicula = dr.GetString(5),
                            clasificacion_pelicula = dr.GetString(6)
                        };
                        lista.Add(p);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lista;
        }
    }
}
