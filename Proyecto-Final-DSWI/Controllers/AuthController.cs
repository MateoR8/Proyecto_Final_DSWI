using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DSWI.Repositories.DAO;
using Proyecto_Final_DSWI.Services;
using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly TokenServices _tokenServices;

        public AuthController(TokenServices tokenServices)
        {
            _tokenServices = tokenServices;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await Task.Run(() => new authDAO().loginAdmin(request.nombreUsuario, request.contrasenia));

            if (user == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            var token = _tokenServices.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
