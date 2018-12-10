using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegistroViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "Digite sua senha")]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}
