using System.ComponentModel.DataAnnotations;

namespace locaweb_rest_api.ViewModels.In
{
    public class InLoginViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MinLength(1, ErrorMessage = "O e-mail não pode ser vazio")]
        [MaxLength(255, ErrorMessage = "O e-mail não deve exceder 150 caracteres")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(1, ErrorMessage = "A senha não pode ser vazia")]
        [MaxLength(255, ErrorMessage = "A senha não pode exceder 255 caracteres")]
        public required string Password { get; set; }
    }
}