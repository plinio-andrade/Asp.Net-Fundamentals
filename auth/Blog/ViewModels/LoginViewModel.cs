using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "O E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O E-mail é inválido")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Informe a senha")]
    public required string Password { get; set; }
}