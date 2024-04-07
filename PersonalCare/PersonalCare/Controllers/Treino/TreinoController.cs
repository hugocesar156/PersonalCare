using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Treino;
using PersonalCare.Application.Models.Responses.Treino;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.API.Controllers.Treino
{
    [ApiController]
    [Route("[controller]")]
    public class TreinoController : ControllerBase
    {
        private readonly ITreino _treino;

        public TreinoController(ITreino treino)
        {
            _treino = treino;
        }

        /// <summary>
        /// Atualiza um registro de treino.
        /// </summary>
        [HttpPut("Atualizar")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Atualizar(AtualizarTreinoRequest request)
        {
            try
            {
                _treino.Atualizar(request);
                return StatusCode((int)HttpStatusCode.OK, "Treino atualizado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Retorna um registro de treino a partir do ID informado.
        /// </summary>
        [HttpGet("Buscar/{idTreino}")]
        [ProducesResponseType(typeof(TreinoResponse), StatusCodes.Status200OK)]
        public IActionResult Buscar(int idTreino)
        {
            try
            {
                var treino = _treino.Buscar(idTreino);
                return StatusCode((int)HttpStatusCode.OK, treino);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Deleta um registro de treino a partir do ID informado.
        /// </summary>
        [HttpDelete("Deletar/{idTreino}")]
        [ProducesResponseType(typeof(TreinoResponse), StatusCodes.Status200OK)]
        public IActionResult Deletar(int idTreino)
        {
            try
            {
                _treino.Deletar(idTreino);
                return StatusCode((int)HttpStatusCode.OK, "Registro de treino removido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere um registro de treino.
        /// </summary>
        [HttpPost("Inserir")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirTreinoRequest request)
        {
            try
            {
                _treino.Inserir(request);
                return StatusCode((int)HttpStatusCode.OK, "Treino inserido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Retorna uma lista de registros de treino.
        /// </summary>
        [HttpGet("Listar")]
        [ProducesResponseType(typeof(List<TreinoResponse>), StatusCodes.Status200OK)]
        public IActionResult Listar(int? idCategoriaTreino)
        {
            try
            {
                var lista = _treino.Listar(idCategoriaTreino ?? 0);
                return StatusCode((int)HttpStatusCode.OK, lista);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
