using System.Data;
using Microsoft.Data.SqlClient;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;

namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class funcionDAO : IFuncionRepository
    {
        private readonly string _cadena;

        public funcionDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetConnectionString("DefaultConnection");
        }

        public string actualizarFunciones(Funciones funciones)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Actualizar_Funcion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_FUNCION", funciones.id_funcion);
                    cmd.Parameters.AddWithValue("@ID_SALA", funciones.id_sala);
                    cmd.Parameters.AddWithValue("@ID_PELICULA", funciones.id_pelicula);
                    cmd.Parameters.AddWithValue("@FECHA_FUNCION", funciones.fecha_funcion);
                    cmd.Parameters.AddWithValue("@HORARIO_FUNCION_INICIO", funciones.hora_inicio);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se actualizó {total} funcion";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public string agregarFunciones(Funciones funciones)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Insertar_Funcion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_SALA", funciones.id_sala);
                    cmd.Parameters.AddWithValue("@ID_PELICULA", funciones.id_pelicula);
                    cmd.Parameters.AddWithValue("@FECHA_FUNCION", funciones.fecha_funcion);
                    cmd.Parameters.AddWithValue("@HORARIO_FUNCION_INICIO", funciones.hora_inicio);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se agregó {total} funcion";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }
        
        public Funciones buscarFuncion(int id)
        {
            return listarFunciones().Where(c => c.id_funcion == id).FirstOrDefault();
        }

        public string eliminarFunciones(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_Funcion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_FUNCION", id);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se eliminó {total} funcion";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public IEnumerable<Funciones> listarFunciones()
        {
            List<Funciones> temporal = new List<Funciones>();
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Listar_Funciones", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Funciones f = new Funciones()
                        {
                            id_funcion = dr.GetInt32(0),
                            id_sala = dr.GetInt32(1),
                            cod_sala = dr.GetString(2),
                            id_pelicula = dr.GetInt32(3),
                            nombre_pelicula = dr.GetString(4),
                            fecha_funcion = DateOnly.FromDateTime(dr.GetDateTime(5)),
                            hora_inicio = TimeOnly.FromTimeSpan(dr.GetTimeSpan(6))
                        };
                        temporal.Add(f);
                    }
                    dr.Close();
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
