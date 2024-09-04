using System.ComponentModel.DataAnnotations;

namespace locaweb_rest_api.ViewModels.In
{
    public class InCreateUserViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MinLength(10, ErrorMessage = "O e-mail deve conter pelo menos 10 caracteres")]
        [MaxLength(255, ErrorMessage = "O e-mail não deve exceder 150 caracteres")]
        [EmailAddress(ErrorMessage = "O e-mail é inválido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório")]
        [MinLength(10, ErrorMessage = "O nome completo deve conter pelo menos 10 caracteres")]
        [MaxLength(50, ErrorMessage = "O nome completo não pode exceder 50 caracteres")]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(10, ErrorMessage = "A senha deve conter pelo menos 10 caracteres")]
        [MaxLength(255, ErrorMessage = "A senha não pode exceder 255 caracteres")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "O idioma é obrigatório")]
        [MinLength(2, ErrorMessage = "O idioma deve ter 2 caracteres")]
        [MaxLength(2, ErrorMessage = "O idioma deve ter 2 caracteres")]
        [RegularExpression("^(pt|en)$", ErrorMessage = "O idioma deve ser 'pt' ou 'en'")]
        public required string Language { get; set; }

        [Required(ErrorMessage = "O tema é obrigatório")]
        public required bool Theme { get; set; }

        [Required(ErrorMessage = "A imagem do usuário é obrigatória")]
        public required IFormFile Image { get; set; }
    }
}
