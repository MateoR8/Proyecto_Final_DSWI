using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_Final_DSWI_Front.Models;

namespace Proyecto_Final_DSWI_Front.Controllers
{
    public class ReservasController : Controller
    {
        private readonly string urlBase = "https://localhost:7042/api/Reserva/";

        public async Task<IActionResult> Index()
        {
            List<Reservas> temporal = new List<Reservas>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("listarReservas");
                string apiResponse = await response.Content.ReadAsStringAsync();
                temporal = JsonConvert.DeserializeObject<List<Reservas>>(apiResponse).ToList();
            }

            return View(await Task.Run(() => temporal));
        }

        [HttpPost]
        public async Task<IActionResult> Index(ReservaFiltros filtros)
        {
            List<Reservas> temporal = new List<Reservas>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                var json = JsonConvert.SerializeObject(filtros);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("listarConFiltros", content);
                string apiResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    temporal = JsonConvert.DeserializeObject<List<Reservas>>(apiResponse).ToList();
                }
            }
            return View(temporal);
        }
    }
}
