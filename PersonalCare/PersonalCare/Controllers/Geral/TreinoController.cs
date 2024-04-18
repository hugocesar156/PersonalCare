using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Treino;
using PersonalCare.Application.Models.Responses.Treino;
using PersonalCare.Application.Permissoes;
using PersonalCare.Shared;
using System.Net;
using static PersonalCare.Shared.PersonalCareEnums;

namespace PersonalCare.API.Controllers.Geral
{
    [Authorize]
    [ApiController]
    [Route("geral/treino")]
    [ApiExplorerSettings(GroupName = "geral")]
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
        [HttpPut("atualizar")]
        [Permissao(Entidade.Treino, Acao.Atualizar)]
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
        [HttpGet("buscar/{idTreino}")]
        [Permissao(Entidade.Treino, Acao.Visualizar)]
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
        [HttpDelete("deletar/{idTreino}")]
        [Permissao(Entidade.Treino, Acao.Deletar)]
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
        [HttpPost("inserir")]
        [Permissao(Entidade.Treino, Acao.Inserir)]
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
        [HttpGet("listar")]
        [Permissao(Entidade.Treino, Acao.Visualizar)]
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
