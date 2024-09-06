using AutoMapper;
using locaweb_rest_api.Models;
using locaweb_rest_api.Services;
using locaweb_rest_api.Services.Impl;
using locaweb_rest_api.ViewModels.Out;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace locaweb_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrashedEmailController : ControllerBase
    {
        private readonly ITrashedEmailService _service;
        private readonly IMapper _mapper;

        public TrashedEmailController(ITrashedEmailService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("")]
        public ActionResult GetAllTrashedEmails([FromQuery] int page = 1)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            List<TrashedEmail> trashedEmails = _service.GetAllTrashedEmails(page, parsedUserId).ToList();

            List<object> parsedTrashedEmails = [];

            foreach (var trashedEmail in trashedEmails)
            {
                if (trashedEmail != null)
                {
                    if (trashedEmail.ReceivedEmail != null)
                        parsedTrashedEmails.Add(trashedEmail.ReceivedEmail);
                    else if(trashedEmail.SentEmail != null)
                        parsedTrashedEmails.Add(trashedEmail.SentEmail);
                }
            }

            parsedTrashedEmails.ForEach(email => {
                if (email is ReceivedEmail receivedEmail)
                    receivedEmail.Image = $"/api/ReceivedEmail/Image/{receivedEmail.Image}";
            });

            List<object> viewModelList = [];

            foreach (var parsedEmail in parsedTrashedEmails)
            {
                if (parsedEmail is ReceivedEmail receivedEmail)
                    viewModelList.Add(_mapper.Map<OutReceivedEmailViewModel>(receivedEmail));
                else if (parsedEmail is SentEmail sentEmail)
                    viewModelList.Add(_mapper.Map<OutSentEmailViewModel>(sentEmail));
            }

            PaginationTrashedEmailViewModel paginationViewModel = new()
            {
                TrashedEmails = viewModelList,
                CurrentPage = page
            };

            return Ok(paginationViewModel);
        }

        [Authorize]
        [HttpGet("ReceivedEmail/{id}")]
        public IActionResult GetTrashedEmailByIdReceivedEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            TrashedEmail? trashedEmail = _service.GetTrashedEmailByIdReceivedEmail(parsedUserId, id);

            if (trashedEmail == null || trashedEmail.ReceivedEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            trashedEmail.ReceivedEmail.Image = $"/api/ReceivedEmail/Image/{trashedEmail.ReceivedEmail.Image}";

            OutReceivedEmailViewModel viewModel = _mapper.Map<OutReceivedEmailViewModel>(trashedEmail.ReceivedEmail);

            return Ok(viewModel);
        }

        [Authorize]
        [HttpGet("SentEmail/{id}")]
        public IActionResult GetTrashedEmailByIdSentEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            TrashedEmail? trashedEmail = _service.GetTrashedEmailByIdSentEmail(parsedUserId, id);

            if (trashedEmail == null || trashedEmail.SentEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            OutSentEmailViewModel viewModel = _mapper.Map<OutSentEmailViewModel>(trashedEmail.SentEmail);

            return Ok(viewModel);
        }
    }
}
