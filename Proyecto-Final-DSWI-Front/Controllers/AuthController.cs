using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DSWI_Front.Models;
using Proyecto_Final_DSWI_Front.Services;

namespace Proyecto_Final_DSWI_Front.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var success = await _authService.LoginAsync(model.nombreUsuario, model.contrasenia);
            if (!success)
            {
                ModelState.AddModelError("", "Login incorrecto");
                Console.WriteLine("error login");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _authService.Logout();
            return RedirectToAction("Login");
        }
    }
}
