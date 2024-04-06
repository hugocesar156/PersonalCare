using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Responses.Conta;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.API.Controllers.Conta
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IConta _conta;

        public ContaController(IConta conta)
        {
            _conta = conta;
        }

        /// <summary>
        /// Retorna registro de conta a partir do ID da conta informado.
        /// </summary>
        [HttpGet("Buscar/{idConta}")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public IActionResult Buscar(int idConta)
        {
            try
            {
                var conta = _conta.Buscar(idConta);
                return StatusCode((int)HttpStatusCode.OK, conta);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere um registro de conta.
        /// </summary>
        [HttpPost("Inserir")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public IActionResult Inserir(ContaRequest request)
        {
            try
            {
                var conta = _conta.Inserir(request);
                return StatusCode((int)HttpStatusCode.OK, conta);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Retorna uma lista de contas.
        /// </summary>
        [HttpGet("Listar")]
        [ProducesResponseType(typeof(List<ContaResponse>), StatusCodes.Status200OK)]
        public IActionResult Listar()
        {
            try
            {
                var lista = _conta.Listar();
                return StatusCode((int)HttpStatusCode.OK, lista);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
