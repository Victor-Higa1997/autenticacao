using autenticacao.Models;

namespace autenticacao.UseCases
{
    public interface ITokenUseCases
    {
        string GerarTokenJwt(Usuario usuario);
    }
}
