using Microsoft.AspNetCore.Identity;

namespace autenticacao.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }

        public Usuario() : base()
        {
            
        }
    }
}
