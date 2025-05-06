using System.Data;
using Microsoft.Data.SqlClient;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;

namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class reservaDAO : IReservaRepository
    {
        private readonly string _cadena;

        public reservaDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Reservas> listarReservas()
        {
            List<Reservas> lista = new List<Reservas>();
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Listar_Reservas", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Reservas r = new Reservas()
                        {
                            idReserva = dr.GetInt32(0),
                            fechaReserva = DateOnly.FromDateTime(dr.GetDateTime(1)),
                            nombreCliente = dr.GetString(2),
                            apellidoPatCliente = dr.GetString(3),
                            apellidoMatCliente = dr.GetString(4),
                            correoCliente = dr.GetString(5),
                            fechaFuncion = DateOnly.FromDateTime(dr.GetDateTime(6)),
                            nombrePelicula = dr.GetString(7),
                            generoPelicula = dr.GetString(8),
                            clasifPelicula = dr.GetString(9),
                            sala = dr.GetString(10),
                            producto = dr.GetString(11)
                        };
                        lista.Add(r);
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

        public IEnumerable<Reservas> listarReservasConFiltro(ReservaFiltros filtro)
        {
            List<Reservas> lista = new List<Reservas>();

            try
            {
                SqlConnection connection = new SqlConnection(_cadena);
                connection.Open();
                SqlCommand command = new SqlCommand("sp_Listar_ReservasConFiltros", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@fechaReserva", (object)filtro.fechaReserva ?? DBNull.Value);
                command.Parameters.AddWithValue("@nombresCliente", (object)filtro.nombresCliente ?? DBNull.Value);
                command.Parameters.AddWithValue("@apePaterno", (object)filtro.apePaterno ?? DBNull.Value);
                command.Parameters.AddWithValue("@apeMaterno", (object)filtro.apeMaterno ?? DBNull.Value);
                command.Parameters.AddWithValue("@fechaFuncion", (object)filtro.fechaFuncion ?? DBNull.Value);
                command.Parameters.AddWithValue("@nombrePelicula", (object)filtro.nombrePelicula ?? DBNull.Value);
                command.Parameters.AddWithValue("@codigoSala", (object)filtro.codigoSala ?? DBNull.Value);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reservas reserva = new Reservas
                    {
                        idReserva = reader.GetInt32(0),
                        fechaReserva = DateOnly.FromDateTime(reader.GetDateTime(1)),
                        nombreCliente = reader.GetString(2),
                        apellidoPatCliente = reader.GetString(3),
                        apellidoMatCliente = reader.GetString(4),
                        correoCliente = reader.GetString(5),
                        fechaFuncion = DateOnly.FromDateTime(reader.GetDateTime(6)),
                        nombrePelicula = reader.GetString(7),
                        generoPelicula = reader.GetString(8),
                        clasifPelicula = reader.GetString(9),
                        sala = reader.GetString(10),
                        producto = reader.GetString(11)
                    };
                    lista.Add(reserva);
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
