using System.ComponentModel.DataAnnotations;

namespace locaweb_rest_api.ViewModels.In
{
    public class InCreateUserViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MinLength(1, ErrorMessage = "O e-mail não pode ser vazio")]
        [MaxLength(255, ErrorMessage = "O e-mail não deve exceder 150 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório")]
        [MinLength(1, ErrorMessage = "O nome completo não pode ser vazio")]
        [MaxLength(50, ErrorMessage = "O nome completo não pode exceder 50 caracteres")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(1, ErrorMessage = "A senha não pode ser vazia")]
        [MaxLength(255, ErrorMessage = "A senha não pode exceder 255 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O idioma é obrigatório")]
        [MinLength(1, ErrorMessage = "O idioma não pode ser vazio")]
        [MaxLength(2, ErrorMessage = "O idioma não pode exceder 2 caracteres")]
        public string Language { get; set; }

        [Required(ErrorMessage = "O tema é obrigatório")]
        public bool Theme { get; set; }

        [Required(ErrorMessage = "A imagem do usuário é obrigatória")]
        public IFormFile Image { get; set; }
    }
}
