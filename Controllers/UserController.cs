using AutoMapper;
using locaweb_rest_api.Models;
using locaweb_rest_api.Services;
using locaweb_rest_api.ViewModels.In;
using locaweb_rest_api.ViewModels.Out;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace locaweb_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create([FromForm] InCreateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User? usuario = _service.GetUserByEmail(viewModel.Email);
            if (usuario != null)
                return Conflict("O usuário já existe");

            User newUser = _mapper.Map<User>(viewModel);
            _service.CreateUser(newUser, viewModel.Image);

            OutUserViewModel outViewModel = _mapper.Map<OutUserViewModel>(newUser);
            outViewModel.Image = Url.Action("GetUserImage", new { filename = newUser.Image });

            return CreatedAtAction(nameof(Create), new { id = newUser.Id }, outViewModel);
        }

        [AllowAnonymous]
        [HttpGet("Image/{filename}")]
        public ActionResult GetUserImage(string filename)
        {
            var imagePath = Path.Combine("uploads", filename);

            if (!System.IO.File.Exists(imagePath))
                return NotFound("Imagem não encontrada");

            var image = System.IO.File.ReadAllBytes(imagePath);

            return File(image, "image/jpeg");
        }

        [Authorize]
        [HttpPut("Preferences")]
        public ActionResult UpdateUserPreferences([FromBody] InUpdateUserPreferencesViewModel viewModel)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized("Usuário não autenticado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User user = _service.GetUserById(int.Parse(userId));

            if (user == null)
                return Unauthorized("Usuário não autenticado");

            user.Theme = viewModel.Theme;
            user.Language = viewModel.Language;

            _service.UpdateUserPreferences(user);

            OutUserViewModel outViewModel = _mapper.Map<OutUserViewModel>(user);
            outViewModel.Image = Url.Action("GetUserImage", new { filename = user.Image });

            return Ok(outViewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetUserInfo()
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized("Usuário não autenticado");

            User user = _service.GetUserById(int.Parse(userId));

            if (user == null)
                return Unauthorized("Usuário não autenticado");

            OutUserViewModel outViewModel = _mapper.Map<OutUserViewModel>(user);
            outViewModel.Image = Url.Action("GetUserImage", new { filename = user.Image });

            return Ok(outViewModel);
        }
    }
}
