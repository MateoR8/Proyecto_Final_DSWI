using System.Data;
using Microsoft.Data.SqlClient;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;

namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class dulceriaDAO : IDulceriaRepository
    {
        private readonly string _cadena;

        public dulceriaDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetConnectionString("DefaultConnection");
        }

        public string actualizarProducto(Dulceria dulceria)
        {
            string mensaje = "";

            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizar_dulce", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PRODUCTO", dulceria.id_producto);
                    cmd.Parameters.AddWithValue("@NOMBRE_PRODUCTO", dulceria.nombre_producto);
                    cmd.Parameters.AddWithValue("@PRECIO_PRODUCTO", dulceria.precio_producto);
                    cmd.Parameters.AddWithValue("@MARCA_PRODUCTO", dulceria.marca_producto);
                    cn.Open();
                    int totalRegistro = cmd.ExecuteNonQuery();
                    mensaje = $"Se guardó {totalRegistro} producto";

                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }

            return mensaje;
        }

        public string agregarProducto(Dulceria dulceria)
        {
            string mensaje = "";

            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_registrar_dulce", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE_PRODUCTO", dulceria.nombre_producto);
                    cmd.Parameters.AddWithValue("@PRECIO_PRODUCTO", dulceria.precio_producto);
                    cmd.Parameters.AddWithValue("@MARCA_PRODUCTO", dulceria.marca_producto);
                    cn.Open();
                    int totalRegistro = cmd.ExecuteNonQuery();
                    mensaje = $"Se guardó {totalRegistro} producto";

                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }

            return mensaje;
        }

        public Dulceria buscarProducto(int id)
        {
            return listarProductos().Where(v => v.id_producto == id).FirstOrDefault();
        }

        public string eliminarProducto(int id)
        {
            string mensaje = "";

            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminar_dulce", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PRODUCTO", id);
                    cn.Open();
                    int totalRegistro = cmd.ExecuteNonQuery();
                    mensaje = $"Se eliminó {totalRegistro} producto";

                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }

            return mensaje;
        }

        public IEnumerable<Dulceria> listarProductos()
        {
            List<Dulceria> temporal = new List<Dulceria>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(_cadena))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("sp_listar_dulceria", cnn);  
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Dulceria d = new Dulceria()
                        {
                            id_producto = rd.GetInt32(0),
                            nombre_producto = rd.GetString(1),
                            precio_producto = rd.GetDecimal(2),
                            marca_producto = rd.GetString(3)
                        };
                        temporal.Add(d);    
                    }
                    rd.Close();
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return temporal;
        }
    }
}
