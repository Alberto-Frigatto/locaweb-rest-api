using locaweb_rest_api.Models;
using System.ComponentModel.DataAnnotations;

namespace locaweb_rest_api.ViewModels.In
{
    public class InSentEmailViewModel
    {
        [Required(ErrorMessage = "O destinatário é obrigatório")]
        [MinLength(1, ErrorMessage = "O destinatário não pode ser vazio")]
        [MaxLength(150, ErrorMessage = "O destinatário não deve exceder 150 caracteres")]
        public string Recipient { get; set; }

        [Required(ErrorMessage = "O assunto é obrigatório")]
        [MinLength(1, ErrorMessage = "O assunto não pode ser vazio")]
        [MaxLength(255, ErrorMessage = "O assunto não deve exceder 255 caracteres")]
        public string Subject { get; set; }
        
        [Required(ErrorMessage = "O corpo do e-mail é obrigatório")]
        [MinLength(1, ErrorMessage = "O corpo do e-mail não pode ser vazio")]
        [MaxLength(255, ErrorMessage = "O corpo do e-mail não pode exceder 255 caracteres")]
        public string Body { get; set; }
        
        [Required(ErrorMessage = "O id do usuário é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do usuário é inválido")]
        public int IdUser { get; set; }
    }
}
