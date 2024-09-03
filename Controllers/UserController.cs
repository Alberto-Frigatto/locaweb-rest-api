﻿using AutoMapper;
using locaweb_rest_api.Models;
using locaweb_rest_api.Services;
using locaweb_rest_api.ViewModels.In;
using locaweb_rest_api.ViewModels.Out;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        [HttpGet("Image/{filename}")]
        public ActionResult GetUserImage(string filename)
        {
            var imagePath = Path.Combine("uploads", filename);

            if (!System.IO.File.Exists(imagePath))
                return NotFound("Imagem não encontrada");

            var image = System.IO.File.ReadAllBytes(imagePath);

            return File(image, "image/jpeg");
        }
    }
}