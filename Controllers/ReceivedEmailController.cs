using AutoMapper;
using locaweb_rest_api.Services;
using locaweb_rest_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using locaweb_rest_api.ViewModels.Out;

namespace locaweb_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceivedEmailController : ControllerBase
    {
        private readonly IReceivedEmailService _receivedEmailService;
        private readonly IFavoriteReceivedEmailService _favoriteReceivedEmailService;
        private readonly ITrashedEmailService _trashedEmailService;
        private readonly IDeletedReceivedEmailService _deletedReceivedEmailService;
        private readonly IMapper _mapper;

        public ReceivedEmailController(
            IReceivedEmailService receivedEmailService,
            IFavoriteReceivedEmailService favoriteReceivedEmailService,
            ITrashedEmailService trashedEmailService,
            IDeletedReceivedEmailService deletedReceivedEmailService,
            IMapper mapper
        ) {
            _receivedEmailService = receivedEmailService;
            _favoriteReceivedEmailService = favoriteReceivedEmailService;
            _trashedEmailService = trashedEmailService;
            _deletedReceivedEmailService = deletedReceivedEmailService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("")]
        public ActionResult GetAllReceivedEmails([FromQuery] int page = 1)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            List<ReceivedEmail> receivedEmails = _receivedEmailService.GetAllReceivedEmails(page, parsedUserId).ToList();

            receivedEmails.ForEach(receivedEmail => {
                receivedEmail.Image = Url.Action("GetReceivedEmailImage", new { filename = receivedEmail.Image });
            });

            IEnumerable<OutReceivedEmailViewModel> viewModelList = _mapper
                .Map<IEnumerable<OutReceivedEmailViewModel>>(receivedEmails);

            PaginationReceivedEmailViewModel paginationViewModel = new()
            {
                ReceivedEmails = viewModelList,
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
            List<ReceivedEmail> receivedEmails = _receivedEmailService.SearchReceivedEmails(query.Trim(), page, parsedUserId).ToList();

            receivedEmails.ForEach(receivedEmail => {
                receivedEmail.Image = Url.Action("GetReceivedEmailImage", new { filename = receivedEmail.Image });
            });

            IEnumerable<OutReceivedEmailViewModel> viewModelList = _mapper
                .Map<IEnumerable<OutReceivedEmailViewModel>>(receivedEmails);

            PaginationReceivedEmailViewModel paginationViewModel = new()
            {
                ReceivedEmails = viewModelList,
                CurrentPage = page
            };

            return Ok(paginationViewModel);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetReceivedEmailById(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            ReceivedEmail? receivedEmail = _receivedEmailService.GetReceivedEmailById(id, parsedUserId);

            if (receivedEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            OutReceivedEmailViewModel viewModel = _mapper.Map<OutReceivedEmailViewModel>(receivedEmail);

            return Ok(viewModel);
        }

        [Authorize]
        [HttpPost("{id}/Favorite")]
        public IActionResult FavoriteReceivedEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            ReceivedEmail? receivedEmail = _receivedEmailService.GetReceivedEmailById(id, parsedUserId);

            if (receivedEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            FavoriteReceivedEmail favoriteEmail = new()
            {
                IdReceivedEmail = id,
                IdUser = parsedUserId
            };

            _favoriteReceivedEmailService.CreateFavoriteReceivedEmail(favoriteEmail);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}/Favorite")]
        public IActionResult UnfavoriteReceivedEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            ReceivedEmail? receivedEmail = _receivedEmailService.GetReceivedEmailById(id, parsedUserId);

            if (receivedEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            _favoriteReceivedEmailService.DeleteFavoriteReceivedEmail(receivedEmail.Id, parsedUserId);

            return NoContent();
        }

        [Authorize]
        [HttpPost("{id}/Trash")]
        public IActionResult TrashReceivedEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);
            ReceivedEmail? receivedEmail = _receivedEmailService.GetReceivedEmailById(id, parsedUserId);

            if (receivedEmail == null)
                return NotFound(new OutErrorViewModel() { error = "Email não encontrado" });

            TrashedEmail trashedEmail = new()
            {
                IdReceivedEmail = id,
                IdUser = parsedUserId
            };

            _trashedEmailService.CreateTrashedEmail(trashedEmail);
            _favoriteReceivedEmailService.DeleteFavoriteReceivedEmail(id, parsedUserId);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}/Trash")]
        public IActionResult RestoreReceivedEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);

            _trashedEmailService.DeleteTrashedEmailByIdReceivedEmail(parsedUserId, id);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteReceivedEmail(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
                return Unauthorized(new OutErrorViewModel() { error = "Usuário não autenticado" });

            int parsedUserId = int.Parse(userId);

            DeletedReceivedEmail deletedReceivedEmail = new()
            {
                IdReceivedEmail = id,
                IdUser = parsedUserId
            };

            _deletedReceivedEmailService.CreateDeletedReceivedEmail(deletedReceivedEmail);
            _favoriteReceivedEmailService.DeleteFavoriteReceivedEmail(id, parsedUserId);
            _trashedEmailService.DeleteTrashedEmailByIdReceivedEmail(parsedUserId, id);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("Image/{filename}")]
        public ActionResult GetReceivedEmailImage(string filename)
        {
            var imagePath = Path.Combine("Public", "Imgs", filename);

            if (!System.IO.File.Exists(imagePath))
                return NotFound(new OutErrorViewModel() { error = "Imagem não encontrada" });

            var image = System.IO.File.ReadAllBytes(imagePath);

            return File(image, "image/jpeg");
        }
    }
}
