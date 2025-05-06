using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_Final_DSWI_Front.Models;

namespace Proyecto_Final_DSWI_Front.Controllers
{
    public class SalasController : Controller
    {
        private readonly string urlBase = "https://localhost:7042/api/Sala/";

        public async Task<IActionResult> Index()
        {
            List<Salas> temporal = new List<Salas>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("getSalas");
                string apiResponse = await response.Content.ReadAsStringAsync();
                temporal = JsonConvert.DeserializeObject<List<Salas>>(apiResponse).ToList();
            }

            return View(await Task.Run(() => temporal));
        }

        public async Task<IActionResult> Create()
        {
            return View(await Task.Run(() => new Salas()));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Salas sal)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sal), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlBase + "agregarSala", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                TempData["Message"] = apiResponse;
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Salas sala = new Salas();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlBase + $"buscarSala?id={id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                sala = JsonConvert.DeserializeObject<Salas>(apiResponse);
            }
            return View(await Task.Run(() => sala));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Salas sal)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sal), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlBase + "actualizarSala", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                TempData["Message"] = apiResponse;
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Salas sala = new Salas();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(urlBase + $"buscarSala?id={id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                sala = JsonConvert.DeserializeObject<Salas>(apiResponse);
            }
            return View(await Task.Run(() => sala));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(urlBase + $"eliminarSala?id={id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                TempData["Message"] = apiResponse;
            }

            return RedirectToAction("Index");
        }

    }
}
