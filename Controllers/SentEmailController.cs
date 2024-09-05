using AutoMapper;
using locaweb_rest_api.Services;
using locaweb_rest_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using locaweb_rest_api.ViewModels.Out;
using System.Security.Claims;
using locaweb_rest_api.ViewModels.In;
using locaweb_rest_api.Services.Impl;

namespace locaweb_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentEmailController : ControllerBase
    {
        private readonly ISentEmailService _sentEmailService;
        private readonly ITrashedEmailService _trashedEmailService;
        private readonly IMapper _mapper;

        public SentEmailController(
            ISentEmailService sentEmailService,
            ITrashedEmailService trashedEmailService,
            IMapper mapper
        ) {
            _sentEmailService = sentEmailService;
            _trashedEmailService = trashedEmailService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("")]
        public IActionResult GetAllSentEmails([FromQuery ]int page)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            List<SentEmail> sentEmails = _sentEmailService.GetAllSentEmails(page, parsedUserId).ToList();

            IEnumerable<OutSentEmailViewModel> viewModelList = _mapper
                .Map<IEnumerable<OutSentEmailViewModel>>(sentEmails);

            PaginationSentEmailViewModel paginationViewModel = new()
            {
                SentEmails = viewModelList,
                CurrentPage = page
            };

            return Ok(paginationViewModel);
        }

        [Authorize]
        [HttpGet("Search/{query}")]
        public ActionResult SearchReceivedEmails(string query, [FromQuery] int page = 1)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            List<SentEmail> sentEmails = _sentEmailService.SearchSentEmails(query.Trim(), page, parsedUserId).ToList();

            IEnumerable<OutSentEmailViewModel> viewModelList = _mapper
                .Map<IEnumerable<OutSentEmailViewModel>>(sentEmails);

            PaginationSentEmailViewModel paginationViewModel = new()
            {
                SentEmails = viewModelList,
                CurrentPage = page
            };

            return Ok(paginationViewModel);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetSentEmailById(int id)
        {
            SentEmail? sentEmail = _sentEmailService.GetSentEmailById(id);

            if (sentEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            OutSentEmailViewModel viewModel = _mapper.Map<OutSentEmailViewModel>(sentEmail);

            return Ok(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SendEmail([FromBody] InCreateSentEmailViewModel viewModel)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);

            SentEmail? lastSentEmail = _sentEmailService.GetLastSentEmail(parsedUserId);

            TimeZoneInfo timeZoneBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime currentDateTimeBrasilia = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneBrasilia);
            DateOnly currentDateBrasilia = DateOnly.FromDateTime(currentDateTimeBrasilia);

            if (lastSentEmail != null)
            {
                double minuteDifference = currentDateTimeBrasilia
                    .Subtract(lastSentEmail.TimeStamp).TotalMinutes;

                if (minuteDifference < 1)
                    return BadRequest(new OutErrorViewModel() { error = "Você não pode enviar e-mails antes de um minuto do último enviado" });
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SentEmail sentEmail = new()
            {
                IdUser = parsedUserId,
                Recipient = viewModel.Recipient,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
                Canceled = false
            };

            sentEmail.Viewed = new Random().Next(2) == 0 && !sentEmail.Canceled;

            if (!DateOnly.TryParseExact(viewModel.SendDate, "dd/MM/yyyy", out DateOnly dateOnlySendDate))
                return BadRequest(new OutErrorViewModel() { error = "Data de envio do email inválida" });

            if (dateOnlySendDate < currentDateBrasilia)
                return BadRequest(new OutErrorViewModel() { error = "A data de envio do email não pode ser anterior a hoje" });

            sentEmail.SendDate = dateOnlySendDate;
            sentEmail.TimeStamp = currentDateTimeBrasilia;
            sentEmail.Scheduled = dateOnlySendDate > currentDateBrasilia;

            _sentEmailService.CreateSentEmail(sentEmail);

            OutSentEmailViewModel outViewModel = _mapper.Map<OutSentEmailViewModel>(sentEmail);

            return CreatedAtAction(nameof(SendEmail), new { id = sentEmail.Id }, outViewModel);
        }

        [Authorize]
        [HttpPost("{id}/Cancel")]
        public IActionResult CancelScheduledSentEmail(int id)
        {
            SentEmail? sentEmail = _sentEmailService.GetSentEmailById(id);

            if (sentEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            sentEmail.Scheduled = false;
            sentEmail.Canceled = true;

            _sentEmailService.UpdateSentEmail(sentEmail);

            return NoContent();
        }

        [Authorize]
        [HttpPost("{id}/Trash")]
        public IActionResult TrashSentEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            SentEmail? sentEmail = _sentEmailService.GetSentEmailById(id);

            if (sentEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            TrashedEmail trashedEmail = new()
            {
                IdSentEmail = id,
                IdUser = parsedUserId
            };

            _trashedEmailService.CreateTrashedEmail(trashedEmail);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}/Trash")]
        public IActionResult RestoreSentEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);

            _trashedEmailService.DeleteTrashedEmailByIdSentEmail(parsedUserId, id);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteSentEmailById(int id)
        {
            _sentEmailService.DeleteSentEmail(id);

            return NoContent();
        }
    }
}
