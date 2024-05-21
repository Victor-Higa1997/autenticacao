using System.ComponentModel.DataAnnotations;

namespace autenticacao.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ConfirmaSenha { get; set; }
    }
}
