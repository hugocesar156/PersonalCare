using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Ficha;
using PersonalCare.Application.Models.Responses.Ficha;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;

namespace PersonalCare.API.Controllers.Geral
{
    [ApiController]
    [Route("geral/ficha")]
    [ApiExplorerSettings(GroupName = "geral")]
    public class FichaController : ControllerBase
    {
        private readonly IFicha _ficha;

        public FichaController(IFicha ficha)
        {
            _ficha = ficha;
        }

        /// <summary>
        /// Atualiza um registro de ficha do cliente.
        /// </summary>
        [HttpPut("atualizar")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Atualizar(AtualizarFichaRequest request)
        {
            try
            {
                _ficha.Atualizar(request);
                return StatusCode((int)HttpStatusCode.OK, "Registro de ficha atualizado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Atualiza um treino para a ficha do clente.
        /// </summary>
        [HttpPut("atualizaritemficha")]
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
        [HttpGet("buscarfichaconta/{idConta}")]
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
        [HttpPost("inserir")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirFichaRequest request)
        {
            try
            {
                _ficha.Inserir(request, int.Parse(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_USUARIO)));
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
        [HttpPost("inseriritemficha")]
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
        /// Deleta um registro de ficha de cliente a partir do ID informado.
        /// </summary>
        [HttpDelete("deletar/{idFicha}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Deletar(int idFicha)
        {
            try
            {
                _ficha.Deletar(idFicha);
                return StatusCode((int)HttpStatusCode.OK, "Registo de ficha removido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Remove um treino para a ficha do cliente a partir do ID de treino de ficha informado.
        /// </summary>
        [HttpDelete("deletaritemficha/{idItemFicha}")]
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
