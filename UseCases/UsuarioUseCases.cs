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
        public async Task<string> Login(CreateLoginDto loginDto)
        {
            SignInResult resultado = await _signInManager.PasswordSignInAsync(loginDto.Nome, loginDto.Senha, false, false);

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == loginDto.Nome.ToUpper());

            if (resultado.Succeeded)
            {
                string token = GerarTokenJwt(usuario);
                return token;
            }
            else
            {
                return "Usuário ou senha inválidos";
            }
        }
        public string GerarTokenJwt(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim("data", usuario.DataNascimento.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89nOf"));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                 expires: DateTime.Now.AddMinutes(10),
                 claims: claims,
                 signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
