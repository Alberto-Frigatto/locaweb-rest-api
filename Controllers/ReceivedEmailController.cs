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
        private readonly IReceivedEmailService _service;
        private readonly IMapper _mapper;

        public ReceivedEmailController(IReceivedEmailService service, IMapper mapper)
        {
            _service = service;
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
            List<ReceivedEmail> receivedEmails = _service.GetAllReceivedEmails(page, parsedUserId).ToList();

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
