using System.Runtime.Intrinsics.Arm;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_Final_DSWI_Front.Models;

namespace Proyecto_Final_DSWI_Front.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly string urlBase = "https://localhost:7042/api/Pelicula/";

        public async Task<IActionResult> Index()
        {
            List<Peliculas> temporal = new List<Peliculas>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("listarPeliculas");
                string apiResponse = await response.Content.ReadAsStringAsync();
                temporal = JsonConvert.DeserializeObject<List<Peliculas>>(apiResponse).ToList();
            }

            return View(await Task.Run(() => temporal));
        }

        public async Task<IActionResult> Create()
        {
            return View(await Task.Run(() => new Peliculas()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Peliculas pelicula)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                StringContent content = new StringContent(JsonConvert.SerializeObject(pelicula), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("agregarPelicula", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index");

            Peliculas pelicula = new Peliculas();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("buscarPelicula/?id=" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                pelicula = JsonConvert.DeserializeObject<Peliculas>(apiResponse);
            }

            return View(await Task.Run(() => pelicula));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Peliculas pelicula)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                StringContent content = new StringContent(JsonConvert.SerializeObject(pelicula), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("actualizarPelicula", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index");

            Peliculas pelicula = new Peliculas();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("buscarPelicula/?id=" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                pelicula = JsonConvert.DeserializeObject<Peliculas>(apiResponse);
            }

            return View(await Task.Run(() => pelicula));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Peliculas pelicula)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                //StringContent content = new StringContent(JsonConvert.SerializeObject(vendedor), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.DeleteAsync("eliminarPelicula/?id=" + pelicula.id_pelicula);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

    }
}