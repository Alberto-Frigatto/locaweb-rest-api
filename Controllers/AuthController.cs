using locaweb_rest_api.Services;
using locaweb_rest_api.ViewModels.In;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace locaweb_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] InLoginViewModel viewModel)
        {
            var usuarioAutenticado = _service.Authenticate(viewModel.Email, viewModel.Password);

            if (usuarioAutenticado == null)
                return Unauthorized();

            var token = _service.GenerateJwtToken(usuarioAutenticado);

            return Ok(new { Token = token });
        }
    }
}
