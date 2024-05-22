using autenticacao.Data.Dtos;

namespace autenticacao.UseCases
{
    public interface IUsuarioUseCases
    {
        Task<bool> CadastrarUsuarioAsync(CreateUsuarioDto usuarioDto);
        bool Login(CreateLoginDto loginDto);
    }
}
