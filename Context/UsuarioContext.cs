using autenticacao.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace autenticacao.Context
{
    public class UsuarioContext : IdentityDbContext<Usuario>
    {

        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
            
        }

    }
}
