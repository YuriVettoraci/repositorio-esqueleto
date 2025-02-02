using Delivery.Application.Autenticacoes.Servicos.Interfaces;
using Delivery.DataTransfer.Autenticacoes.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers.Autenticacoes
{
    [ApiController]
    [Route("auth")]
    public class AutenticacoesController : Controller
    {
        private readonly IAutenticacaoAppServico autenticacaoServico;

        public AutenticacoesController(IAutenticacaoAppServico autenticacaoServico)
        {
            this.autenticacaoServico = autenticacaoServico;
        }

        [HttpPost("registro")]
        public IActionResult Registro([FromBody] RegistroRequest request)
        {
            var response = autenticacaoServico.Registro(request);

            return Ok(response);
        }

        [HttpGet("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var response = autenticacaoServico.Login(request);

            return Ok(response);
        }
    }
}
