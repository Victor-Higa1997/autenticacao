﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace autenticacao.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {

        [HttpGet]
        [Authorize(Policy = "IdadeMinima")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
