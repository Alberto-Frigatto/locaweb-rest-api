using System.ComponentModel.DataAnnotations;

namespace locaweb_rest_api.ViewModels.In
{
    public class InCreateSentEmailViewModel
    {
        [Required(ErrorMessage = "O destinatário é obrigatório")]
        [MinLength(10, ErrorMessage = "O destinatário deve ter pelo menos 10 caracteres")]
        [MaxLength(150, ErrorMessage = "O destinatário não deve exceder 150 caracteres")]
        [EmailAddress(ErrorMessage = "O e-mail é inválido")]
        public string Recipient { get; set; }

        [Required(ErrorMessage = "O assunto é obrigatório")]
        [MinLength(1, ErrorMessage = "O assunto não pode ser vazio")]
        [MaxLength(255, ErrorMessage = "O assunto não deve exceder 255 caracteres")]
        public string Subject { get; set; }
        
        [Required(ErrorMessage = "O corpo do e-mail é obrigatório")]
        [MinLength(1, ErrorMessage = "O corpo do e-mail não pode ser vazio")]
        [MaxLength(255, ErrorMessage = "O corpo do e-mail não pode exceder 255 caracteres")]
        public string Body { get; set; }

        [Required(ErrorMessage = "O dia de envio é obrigatório")]
        [RegularExpression(@"\d{2}/\d{2}/\d{4}", ErrorMessage = "A data deve estar no formato dd/MM/aaaa")]
        public string SendDate { get; set; }
    }
}
