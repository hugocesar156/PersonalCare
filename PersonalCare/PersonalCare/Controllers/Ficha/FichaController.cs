using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Ficha;
using PersonalCare.Application.Models.Responses.Ficha;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.API.Controllers.Ficha
{
    [ApiController]
    [Route("[controller]")]
    public class FichaController : ControllerBase
    {
        private readonly IFicha _ficha;

        public FichaController(IFicha ficha)
        {
            _ficha = ficha;
        }

        /// <summary>
        /// Atualiza um treino para a ficha do clente.
        /// </summary>
        [HttpPut("AtualizarItemFicha")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AtualizarItemFicha(AtualizarItemFichaRequest request)
        {
            try
            {
                _ficha.AtualizarItemFicha(request);
                return StatusCode((int)HttpStatusCode.OK, "Treino atualizado para a ficha com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Busca o registro de ficha para uma conta a partir do ID da conta informado.
        /// </summary>
        [HttpGet("BuscarFichaConta")]
        [ProducesResponseType(typeof(FichaResponse), StatusCodes.Status200OK)]
        public IActionResult BuscarFichaConta(int idConta)
        {
            try
            {
                var ficha = _ficha.BuscarFichaConta(idConta);
                return StatusCode((int)HttpStatusCode.OK, ficha);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere um registro de ficha de treino para um cliente.
        /// </summary>
        [HttpPost("Inserir")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirFichaRequest request)
        {
            try
            {
                _ficha.Inserir(request);
                return StatusCode((int)HttpStatusCode.OK, "Registro de ficha inserido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere um novo treino para a ficha do clente.
        /// </summary>
        [HttpPost("InserirItemFicha")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult InserirItemFicha(InserirItemFichaRequest request)
        {
            try
            {
                _ficha.InserirItemFicha(request);
                return StatusCode((int)HttpStatusCode.OK, "Treino adicionado para a ficha com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Remove um treino para a ficha do cliente a partir do ID de treino de ficha informado.
        /// </summary>
        [HttpDelete("DeletarItemFicha")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult DeletarItemFicha(int idItemFicha)
        {
            try
            {
                _ficha.DeletarItemFicha(idItemFicha);
                return StatusCode((int)HttpStatusCode.OK, "Treino removido da ficha com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
