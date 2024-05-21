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

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto usuarioDto)
        {
            try
            {
                return await _usuarioUseCases.CadastrarUsuario(usuarioDto) ? Ok("Usuario cadastrado!") : throw new Exception();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

    }
}
