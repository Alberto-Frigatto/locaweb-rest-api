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
    public class FavoriteReceivedEmailController : ControllerBase
    {
        private readonly IFavoriteReceivedEmailService _favoriteReceivedEmailService;
        private readonly IMapper _mapper;

        public FavoriteReceivedEmailController(
            IFavoriteReceivedEmailService favoriteReceivedEmailService,
            IMapper mapper
        )
        {
            _favoriteReceivedEmailService = favoriteReceivedEmailService;
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
            List<FavoriteReceivedEmail> favoriteReceivedEmails = _favoriteReceivedEmailService
                .GetAllFavoriteReceivedEmails(page, parsedUserId).ToList();

            List<ReceivedEmail> receivedEmails = [];

            foreach (FavoriteReceivedEmail favoriteReceivedEmail in favoriteReceivedEmails)
                receivedEmails.Add(favoriteReceivedEmail.ReceivedEmail);

            receivedEmails.ForEach(receivedEmail => {
                receivedEmail.Image = $"/api/ReceivedEmail/Image/{receivedEmail.Image}";
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
    }
}
