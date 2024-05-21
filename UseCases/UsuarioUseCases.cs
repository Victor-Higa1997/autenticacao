using autenticacao.Data.Dtos;
using autenticacao.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace autenticacao.UseCases
{
    public class UsuarioUseCases : IUsuarioUseCases
    {
        private IMapper _mapper;
        private UserManager<Usuario> _usuarioManager;

        public UsuarioUseCases(IMapper mapper, UserManager<Usuario> usuarioManager)
        {
            _mapper = mapper;
            _usuarioManager = usuarioManager;
        }
        public async Task<bool> CadastrarUsuario(CreateUsuarioDto usuarioDto)
        {

            try
            {
                Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

                IdentityResult resultado = await _usuarioManager.CreateAsync(usuario, usuarioDto.Senha);

                return resultado.Succeeded;
            }
            catch (Exception)
            {
                throw;
            }

            

        }
    }
}
