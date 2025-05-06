using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_Final_DSWI_Front.Models;

namespace Proyecto_Final_DSWI_Front.Controllers
{
    public class DulceriaController : Controller
    {
        private readonly string urlBase = "https://localhost:7042/api/Dulceria/";

        public async Task<IActionResult> Index()
        {
            List<Dulceria> temporal = new List<Dulceria>();

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("getProductos");
                string apiResponse = await response.Content.ReadAsStringAsync();
                temporal = JsonConvert.DeserializeObject<List<Dulceria>>(apiResponse).ToList();
            }

            return View(await Task.Run(() => temporal));
        }

        public async Task<IActionResult> Create()
        {
            return View(await Task.Run(() => new Dulceria()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dulceria prod)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (var client = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(prod), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlBase + "agregarProducto", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                TempData["Message"] = apiResponse;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Dulceria prod = new Dulceria();

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = await client.GetAsync(urlBase + $"buscarProducto?id={id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                prod = JsonConvert.DeserializeObject<Dulceria>(apiResponse);
            }

            return View(await Task.Run(() => prod));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Dulceria prod)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (var client = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(prod), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlBase + "actualizarProducto", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                TempData["Message"] = apiResponse;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Dulceria prod = new Dulceria();

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = await client.GetAsync(urlBase + $"buscarProducto?id={id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                prod = JsonConvert.DeserializeObject<Dulceria>(apiResponse);
            }

            return View(await Task.Run(() => prod));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = await client.DeleteAsync(urlBase + $"eliminarProducto?id={id}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                TempData["Message"] = apiResponse;
            }

            return RedirectToAction("Index");
        }
    }
}
