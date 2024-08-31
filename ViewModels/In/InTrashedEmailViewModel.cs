using locaweb_rest_api.Models;
using System.ComponentModel.DataAnnotations;

namespace locaweb_rest_api.ViewModels.In
{
    public class InTrashedEmailViewModel
    {
        [Required(ErrorMessage = "O id do e-mail recebido é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do e-mail recebido é inválido")]
        public int? IdReceivedEmail { get; set; }

        [Required(ErrorMessage = "O id do e-mail enviado é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do e-mail enviado é inválido")]
        public int? IdSentEmail { get; set; }

        [Required(ErrorMessage = "O id do usuário é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do usuário é inválido")]
        public int IdUser { get; set; }
    }
}
