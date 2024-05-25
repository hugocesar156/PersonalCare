using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Conta;
using PersonalCare.Application.Models.Responses.Ficha;
using PersonalCare.Application.Models.Responses.HorarioTreino;
using PersonalCare.Application.Models.Responses.Usuario;
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
        private readonly IFicha _ficha;
        private readonly IHorarioTreinoConta _horarioTreino;

        public PerfilController(IConta conta, IFicha ficha, IHorarioTreinoConta horarioTreino)
        {
            _conta = conta;
            _ficha = ficha;
            _horarioTreino = horarioTreino;

        }

        /// <summary>
        /// Altera a senha da conta.
        /// </summary>
        [HttpPost("alterarsenha")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AlterarSenha(AlterarSenhaRequest request)
        {
            try
            {
                _conta.AlterarSenha(request, int.Parse(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_CONTA)));
                return StatusCode((int)HttpStatusCode.OK, "Senha da conta alterada com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Autentica uma conta.
        /// </summary>
        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarResponse), StatusCodes.Status200OK)]
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
        [HttpGet("buscarconta")]
        [Authorize, PermissaoConta]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public IActionResult BuscarConta()
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

        /// <summary>
        /// Busca o registro de ficha da conta.
        /// </summary>
        [HttpGet("buscarficha")]
        [Authorize, PermissaoConta]
        [ProducesResponseType(typeof(FichaResponse), StatusCodes.Status200OK)]
        public IActionResult BuscarFicha()
        {
            try
            {
                var ficha = _ficha.BuscarFichaConta(int.Parse(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_CONTA)));
                return StatusCode((int)HttpStatusCode.OK, ficha);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Busca o hoário de treino cadastrado para a conta.
        /// </summary>
        [HttpGet("buscarhorariotreino")]
        [ProducesResponseType(typeof(HorarioTreinoContaResponse), StatusCodes.Status200OK)]
        public IActionResult BuscarHorarioTreino()
        {
            try
            {
                var horario = _horarioTreino.Buscar(
                    int.Parse(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_CONTA)),
                    HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));

                return StatusCode((int)HttpStatusCode.OK, horario);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
