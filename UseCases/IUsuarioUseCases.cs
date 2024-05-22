using autenticacao.Data.Dtos;
using autenticacao.Models;

namespace autenticacao.UseCases
{
    public interface IUsuarioUseCases
    {
        Task<bool> CadastrarUsuarioAsync(CreateUsuarioDto usuarioDto);
        Task<string> Login(CreateLoginDto loginDto);
        string GerarTokenJwt(Usuario usuario);
    }
}
