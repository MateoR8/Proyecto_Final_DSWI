using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Proyecto_Final_DSWI_Front.Models;
using Proyecto_Final_DSWI_Front.Services;

namespace Proyecto_Final_DSWI_Front.Controllers
{
    public class ClientesController : Controller
    {

        private readonly string urlBase = "https://localhost:7042/api/Cliente/";
        private readonly AuthService _authService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientesController(AuthService authService, IHttpClientFactory httpClientFactory)
        {
            _authService = authService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var token = _authService.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }

            List<Clientes> temporal = new List<Clientes>();

            var client = _httpClientFactory.CreateClient();
            
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("listarClientes");
                string apiResponse = await response.Content.ReadAsStringAsync();
                temporal = JsonConvert.DeserializeObject<List<Clientes>>(apiResponse).ToList();
            

            return View(await Task.Run(() => temporal));
        }

        public async Task<IActionResult> Create()
        {
            var token = _authService.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(await Task.Run(() => new Clientes()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Clientes cliente)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                StringContent content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("agregarCliente", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var token = _authService.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }

            if (id == null) return RedirectToAction("Index");

            Clientes cliente = new Clientes();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("buscarCliente/?id=" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                cliente = JsonConvert.DeserializeObject<Clientes>(apiResponse);
            }

            return View(await Task.Run(() => cliente));
        }

        [HttpPost] 
        public async Task<IActionResult> Edit(Clientes cliente)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                StringContent content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("actualizarCliente", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = _authService.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }

            if (id == null) return RedirectToAction("Index");

            Clientes cliente = new Clientes();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("buscarCliente/?id=" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                cliente = JsonConvert.DeserializeObject<Clientes>(apiResponse);
            }

            return View(await Task.Run(() => cliente));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Clientes cliente)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.DeleteAsync("eliminarCliente/?id=" + cliente.id_cliente);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

    }
}