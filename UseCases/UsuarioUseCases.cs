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
        private SignInManager<Usuario> _signInManager;

        public UsuarioUseCases(IMapper mapper, UserManager<Usuario> usuarioManager, SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _usuarioManager = usuarioManager;
            _signInManager = signInManager;
        }
        public async Task<bool> CadastrarUsuarioAsync(CreateUsuarioDto usuarioDto)
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

        public bool Login(CreateLoginDto loginDto)
        {
            SignInResult resultado = _signInManager.PasswordSignInAsync(loginDto.Nome, loginDto.Senha, false, false).Result;

            return resultado.Succeeded;
        }   
    }
}
