using System.Text.Json;
using System.Text;

namespace Proyecto_Final_DSWI_Front.Services
{
    public class AuthService
    {
        private readonly string urlBase = "https://localhost:7042/api/";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContext;

        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContext)
        {
            _httpClientFactory = httpClientFactory;
            _httpContext = httpContext;
        }

        public async Task<bool> LoginAsync(string nombreUsuario, string contrasenia)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(urlBase);

            var body = new { nombreUsuario, contrasenia };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Auth/login", content);
            if (!response.IsSuccessStatusCode)
                return false;

            var responseContent = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(responseContent);
            var token = json.RootElement.GetProperty("token").GetString();

            // Guardar token en Session
            _httpContext.HttpContext!.Session.SetString("JWToken", token!);

            return true;
        }

        public string? GetToken()
        {
            return _httpContext.HttpContext?.Session.GetString("JWToken");
        }

        public void Logout()
        {
            _httpContext.HttpContext!.Session.Remove("JWToken");
        }
    }
}
