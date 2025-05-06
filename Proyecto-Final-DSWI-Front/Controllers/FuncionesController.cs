using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Proyecto_Final_DSWI.Models;
using Proyecto_Final_DSWI_Front.Models;

namespace Proyecto_Final_DSWI_Front.Controllers
{
    public class FuncionesController : Controller
    {
        private readonly string urlBase = "https://localhost:7042/api/Funcion/";

        public async Task<IActionResult> Index()
        {
            List<Funciones> temporal = new List<Funciones>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("listarFunciones");
                string apiResponse = await response.Content.ReadAsStringAsync();
                temporal = JsonConvert.DeserializeObject<List<Funciones>>(apiResponse).ToList();
            }

            return View(await Task.Run(() => temporal));
        }

        public async Task<List<PeliculaList>> listarPeliculas()
        {
            List<PeliculaList> temporal = new List<PeliculaList>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("listarPeliculas");
                string apiResponse = await response.Content.ReadAsStringAsync();
                temporal = JsonConvert.DeserializeObject<List<PeliculaList>>(apiResponse).ToList();
            }

            return temporal;
        }

        public async Task<List<SalaList>> listarSalas()
        {
            List<SalaList> temporal = new List<SalaList>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("listarSalas");
                string apiResponse = await response.Content.ReadAsStringAsync();
                temporal = JsonConvert.DeserializeObject<List<SalaList>>(apiResponse).ToList();
            }

            return temporal;
        }

        public async Task<IActionResult> Create()
        {
            var peliculas = await listarPeliculas();
            var salas = await listarSalas();

            ViewBag.peliculas = new SelectList(peliculas, "id_pelicula", "nombre_pelicula");
            ViewBag.salas = new SelectList(salas, "id_sala", "cod_sala");

            return View(await Task.Run(() => new Funciones()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Funciones funcion)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                StringContent content = new StringContent(JsonConvert.SerializeObject(funcion), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("agregarFuncion", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return RedirectToAction("Index");

            Funciones funcion = new Funciones();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("buscarFuncion/?id=" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                funcion = JsonConvert.DeserializeObject<Funciones>(apiResponse);
            }

            var peliculas = await listarPeliculas();
            var salas = await listarSalas();

            ViewBag.peliculas = new SelectList(peliculas, "id_pelicula", "nombre_pelicula", funcion?.id_pelicula);
            ViewBag.salas = new SelectList(salas, "id_sala", "cod_sala", funcion?.id_sala);

            return View(await Task.Run(() => funcion));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Funciones funcion)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                StringContent content = new StringContent(JsonConvert.SerializeObject(funcion), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("actualizarFuncion", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return RedirectToAction("Index");

            Funciones funcion = new Funciones();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("buscarFuncion/?id=" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                funcion = JsonConvert.DeserializeObject<Funciones>(apiResponse);
            }

            var peliculas = await listarPeliculas();
            var salas = await listarSalas();

            ViewBag.peliculas = new SelectList(peliculas, "id_pelicula", "nombre_pelicula", funcion?.id_pelicula);
            ViewBag.salas = new SelectList(salas, "id_sala", "cod_sala", funcion?.id_sala);

            return View(await Task.Run(() => funcion));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Funciones funcion)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.DeleteAsync("eliminarFuncion/?id=" + funcion.id_funcion);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }
    }
}
