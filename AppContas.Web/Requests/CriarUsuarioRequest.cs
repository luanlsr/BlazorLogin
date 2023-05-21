using System.ComponentModel.DataAnnotations;

namespace AppContas.Web.Requests
{
    public class CriarUsuarioRequest
    {
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe seu nome.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email.")]
        public string? Email { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,20}$",
            ErrorMessage = "Informe uma senha forte com no mínimo 6 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe sua senha.")]
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme a sua senha.")]
        public string? ConfirmarSenha { get; set; }
    }
}
