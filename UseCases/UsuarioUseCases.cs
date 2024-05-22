using autenticacao.Data.Dtos;
using autenticacao.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace autenticacao.UseCases
{
    public class UsuarioUseCases : IUsuarioUseCases
    {
        private IMapper _mapper;
        private UserManager<Usuario> _usuarioManager;
        private SignInManager<Usuario> _signInManager;
        private ITokenUseCases _tokenUseCases;

        public UsuarioUseCases(IMapper mapper, UserManager<Usuario> usuarioManager, SignInManager<Usuario> signInManager, ITokenUseCases tokenUseCases)
        {
            _mapper = mapper;
            _usuarioManager = usuarioManager;
            _signInManager = signInManager;
            _tokenUseCases = tokenUseCases;
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
        public async Task<string> Login(CreateLoginDto loginDto)
        {
            SignInResult resultado = await _signInManager.PasswordSignInAsync(loginDto.Nome, loginDto.Senha, false, false);

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == loginDto.Nome.ToUpper());

            if (resultado.Succeeded)
            {
                string token = _tokenUseCases.GerarTokenJwt(usuario);
                return token;
            }
            else
            {
                return "Usuário ou senha inválidos";
            }
        }
    }
}
