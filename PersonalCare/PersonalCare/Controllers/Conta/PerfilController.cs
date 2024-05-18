using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Conta;
using PersonalCare.Application.Permissoes;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;

namespace PersonalCare.API.Controllers.Conta
{
    [ApiController]
    [Route("conta/perfil")]
    [ApiExplorerSettings(GroupName = "conta")]
    public class PerfilController : ControllerBase
    {
        private readonly IConta _conta;

        public PerfilController(IConta conta)
        {
            _conta = conta;
        }

        /// <summary>
        /// Autentica uma conta.
        /// </summary>
        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public IActionResult Autenticar(AutenticarRequest request)
        {
            try
            {
                var response = _conta.Autenticar(request);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Busca o registro de conta.
        /// </summary>
        [HttpGet("buscar")]
        [Authorize, PermissaoConta]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public IActionResult Buscar()
        {
            try
            {
                var conta = _conta.Buscar(int.Parse(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_CONTA)));
                return StatusCode((int)HttpStatusCode.OK, conta);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
