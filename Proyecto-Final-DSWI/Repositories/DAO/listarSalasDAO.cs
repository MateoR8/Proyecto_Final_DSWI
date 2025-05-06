using Microsoft.Data.SqlClient;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI.Repositories.Interfaces;

namespace Proyecto_Final_DSWI.Repositories.DAO
{
    public class listarSalasDAO : IListarSalas
    {
        private readonly string _cadena;

        public listarSalasDAO()
        {
            _cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
        }

        public IEnumerable<SalaList> listarSalas()
        {
            List<SalaList> list = new List<SalaList>();
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Salas_Select", cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SalaList salas = new SalaList()
                        {
                            id_sala = reader.GetInt32(0),
                            cod_sala = reader.GetString(1)
                        };

                        list.Add(salas);
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
