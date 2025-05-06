using Microsoft.Data.SqlClient;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;
using System.Data;

namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class clienteDAO : IClienteRepository
    {
        private readonly string _cadena;

        public clienteDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetConnectionString("DefaultConnection");
        }

        public string agregarCliente(Clientes cliente)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_registrar_cliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI_CLIENTE", cliente.dni_cliente);
                    cmd.Parameters.AddWithValue("@NOMBRES_CLIENTE", cliente.nombres_cliente);
                    cmd.Parameters.AddWithValue("@APELLIDO_PAT_CLIENTE", cliente.apellido_pat_cliente);
                    cmd.Parameters.AddWithValue("@APELLIDO_MAT_CLIENTE", cliente.apellido_mat_cliente);
                    cmd.Parameters.AddWithValue("@NUM_CELULAR_CLIENTE", cliente.num_celular_cliente);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO_CLIENTE", cliente.fecha_nac_cliente);
                    cmd.Parameters.AddWithValue("@CORREO_CLIENTE", cliente.correo_cliente);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se agregó {total} cliente(s)";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public string actualizarCliente(Clientes cliente)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizar_cliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_CLIENTE", cliente.id_cliente);
                    cmd.Parameters.AddWithValue("@DNI_CLIENTE", cliente.dni_cliente);
                    cmd.Parameters.AddWithValue("@NOMBRES_CLIENTE", cliente.nombres_cliente);
                    cmd.Parameters.AddWithValue("@APELLIDO_PAT_CLIENTE", cliente.apellido_pat_cliente);
                    cmd.Parameters.AddWithValue("@APELLIDO_MAT_CLIENTE", cliente.apellido_mat_cliente);
                    cmd.Parameters.AddWithValue("@NUM_CELULAR_CLIENTE", cliente.num_celular_cliente);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO_CLIENTE", cliente.fecha_nac_cliente);
                    cmd.Parameters.AddWithValue("@CORREO_CLIENTE", cliente.correo_cliente);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se actualizó {total} cliente(s)";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public string eliminarCliente(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminar_cliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
                    cn.Open();
                    int total = cmd.ExecuteNonQuery();
                    mensaje = $"Se eliminó {total} cliente(s)";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public Clientes buscarCliente(int id)
        {
            return listarClientes().Where(c => c.id_cliente == id).FirstOrDefault();
        }

        public IEnumerable<Clientes> listarClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_listar_clientes", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Clientes c = new Clientes()
                        {
                            id_cliente = dr.GetInt32(0),
                            dni_cliente = dr.GetString(1),
                            nombres_cliente = dr.GetString(2),
                            apellido_pat_cliente = dr.GetString(3),
                            apellido_mat_cliente = dr.GetString(4),
                            num_celular_cliente = dr.GetString(5),
                            fecha_nac_cliente = DateOnly.FromDateTime(dr.GetDateTime(6)),
                            correo_cliente = dr.GetString(7)
                        };
                        lista.Add(c);
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
