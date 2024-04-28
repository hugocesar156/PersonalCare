using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Permissoes;
using PersonalCare.Shared;
using System.Net;
using static PersonalCare.Shared.PersonalCareEnums;

namespace PersonalCare.API.Controllers.Geral
{
    [Authorize]
    [ApiController]
    [Route("geral/horariotreino")]
    [ApiExplorerSettings(GroupName = "geral")]
    public class HorarioTreinoController : ControllerBase
    {
        private readonly IConta _conta;

        public HorarioTreinoController(IConta conta)
        {
            _conta = conta;
        }

        /// <summary>
        /// Atualiza um horário de treino para a conta com um usuário informado.
        /// </summary>
        [HttpPut("atualizar")]
        [Permissao(Entidade.HorarioTreino, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Atualizar(AtualizarHorarioTreinoRequest request)
        {
            try
            {
                _conta.AtualizarHorarioTreino(request);
                return StatusCode((int)HttpStatusCode.OK, "Horário de treino para a conta atualizado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Deleta um horário de treino para a conta a partir do ID informado.
        /// </summary>
        [HttpDelete("deletar/{idHorarioTreino}")]
        [Permissao(Entidade.HorarioTreino, Acao.Deletar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Deletar(int idHorarioTreino)
        {
            try
            {
                _conta.DeletarHorarioTreino(idHorarioTreino);
                return StatusCode((int)HttpStatusCode.OK, "Horário de treino para a conta removido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere um horário de treino para a conta com um usuário informado.
        /// </summary>
        [HttpPost("inserir")]
        [Permissao(Entidade.HorarioTreino, Acao.Inserir)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirHorarioTreinoRequest request)
        {
            try
            {
                _conta.InserirHorarioTreino(request);
                return StatusCode((int)HttpStatusCode.OK, "Horário de treino para a conta definido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
