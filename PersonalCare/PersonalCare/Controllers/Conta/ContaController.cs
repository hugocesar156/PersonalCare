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
        /// Atualiza um registro de conta.
        /// </summary>
        [HttpPut("Atualizar")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public IActionResult Atualizar(AtualizarContaRequest request)
        {
            try
            {
                var conta = _conta.Atualizar(request);
                return StatusCode((int)HttpStatusCode.OK, conta);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
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
        /// Deleta um registro de conta a partir do ID da conta informado.
        /// </summary>
        [HttpDelete("Deletar/{idConta}")]
        [ProducesResponseType(typeof(ContaResponse), StatusCodes.Status200OK)]
        public IActionResult Deletar(int idConta)
        {
            try
            {
                _conta.Deletar(idConta);
                return StatusCode((int)HttpStatusCode.OK, "Registro de conta deletado com sucesso.");
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
        public IActionResult Inserir(InserirContaRequest request)
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
