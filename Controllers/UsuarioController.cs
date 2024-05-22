using autenticacao.Context;
using autenticacao.Data.Dtos;
using autenticacao.Models;
using autenticacao.UseCases;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace autenticacao.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCases _usuarioUseCases;

        public UsuarioController(IUsuarioUseCases usuarioUseCases)
        {
            _usuarioUseCases = usuarioUseCases;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto usuarioDto)
        {
            try
            {
                return await _usuarioUseCases.CadastrarUsuarioAsync(usuarioDto) ? Ok("Usuario cadastrado!") : throw new Exception();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CreateLoginDto loginDto)
        {
            try
            {
                var token = await _usuarioUseCases.Login(loginDto);
                return token != null ? Ok(token) : throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

    }
}
