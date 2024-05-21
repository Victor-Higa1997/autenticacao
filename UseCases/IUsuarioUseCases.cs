using autenticacao.Data.Dtos;

namespace autenticacao.UseCases
{
    public interface IUsuarioUseCases
    {
        Task<bool> CadastrarUsuario(CreateUsuarioDto usuarioDto);
    }
}
