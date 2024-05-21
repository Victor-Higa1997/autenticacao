using Microsoft.AspNetCore.Mvc;

namespace autenticacao.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {

        [HttpPost]
        public IActionResult CadastrarUsuario()
        {
            throw new NotImplementedException();
        }

    }
}
