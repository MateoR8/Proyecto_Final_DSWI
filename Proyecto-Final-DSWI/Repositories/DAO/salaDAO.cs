using System.Data;
using Microsoft.Data.SqlClient;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;

namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class salaDAO : ISalaRepository
    {
        private readonly string _cadena;

        public salaDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetConnectionString("DefaultConnection");
        }

        public string actualizarSala(Salas salas)
        {
            string mensaje = "";

            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizar_sala", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_SALA", salas.id_sala);
                    cmd.Parameters.AddWithValue("@COD_SALA", salas.cod_sala);
                    cmd.Parameters.AddWithValue("@CAPACIDAD_SALA", salas.capacidad_sala);
                    cn.Open();
                    int totalRegistro = cmd.ExecuteNonQuery();
                    mensaje = $"Se guardó {totalRegistro} sala";

                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }

            return mensaje;
        }

        public string agregarSalas(Salas salas)
        {
            string mensaje = "";

            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_registrar_sala", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_SALA", salas.cod_sala);
                    cmd.Parameters.AddWithValue("@CAPACIDAD_SALA", salas.capacidad_sala);
                    cn.Open();
                    int totalRegistro = cmd.ExecuteNonQuery();
                    mensaje = $"Se guardó {totalRegistro} sala";

                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }

            return mensaje;
        }

        public Salas buscarSala(int id)
        {
            return listarSalas().Where(v => v.id_sala == id).FirstOrDefault();
        }

        public string eliminarSala(int id)
        {
            string mensaje = "";

            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminar_sala", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_SALA", id);
                    cn.Open();
                    int totalRegistro = cmd.ExecuteNonQuery();
                    mensaje = $"Se eliminó {totalRegistro} sala";

                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message; 
                }
            }

            return mensaje;
        }

        public IEnumerable<Salas> listarSalas()
        {
            List<Salas> temporal = new List<Salas>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cadena))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("sp_listar_salas", cnn);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Salas s = new Salas()
                        {
                            id_sala = rd.GetInt32(0),
                            cod_sala = rd.GetString(1),
                            capacidad_sala = rd.GetInt32(2)
                        };
                        temporal.Add(s);
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return temporal;
        }
    }
}
