using System.ComponentModel.DataAnnotations;

namespace locaweb_rest_api.ViewModels.In
{
    public class InUpdateUserPreferencesViewModel
    {
        [Required(ErrorMessage = "O idioma é obrigatório")]
        [MinLength(2, ErrorMessage = "O idioma deve ter 2 caracteres")]
        [MaxLength(2, ErrorMessage = "O idioma deve ter 2 caracteres")]
        [RegularExpression("^(pt|en)$", ErrorMessage = "O idioma deve ser 'pt' ou 'en'")]
        public required string Language { get; set; }

        [Required(ErrorMessage = "O tema é obrigatório")]
        public bool Theme { get; set; }
    }
}
