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
        public ActionResult Create([FromBody] InCreateUserViewModel viewModel)
        {
            Console.WriteLine("PORRA CARALHO");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User? usuario = _service.GetUserByEmail(viewModel.Email);
            if (usuario != null)
                return Conflict(new OutErrorViewModel() { error = "O usuário já existe" });

            User newUser = _mapper.Map<User>(viewModel);
            _service.CreateUser(newUser);

            OutUserViewModel outViewModel = _mapper.Map<OutUserViewModel>(newUser);

            return CreatedAtAction(nameof(Create), new { id = newUser.Id }, outViewModel);
        }

        [Authorize]
        [HttpPut("Preferences")]
        public ActionResult UpdateUserPreferences([FromBody] InUpdateUserPreferencesViewModel viewModel)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User? user = _service.GetUserById(int.Parse(userId));

            if (user == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            user.Theme = viewModel.Theme;
            user.Language = viewModel.Language;

            _service.UpdateUserPreferences(user);

            OutUserViewModel outViewModel = _mapper.Map<OutUserViewModel>(user);

            return Ok(outViewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetUserInfo()
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            User user = _service.GetUserById(int.Parse(userId));

            if (user == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            OutUserViewModel outViewModel = _mapper.Map<OutUserViewModel>(user);

            return Ok(outViewModel);
        }
    }
}
