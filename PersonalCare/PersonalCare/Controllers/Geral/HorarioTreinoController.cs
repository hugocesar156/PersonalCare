using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.HorarioTreino;
using PersonalCare.Application.Models.Responses.HorarioTreino;
using PersonalCare.Application.Permissoes;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;
using static PersonalCare.Shared.PersonalCareEnums;

namespace PersonalCare.API.Controllers.Geral
{
    [Authorize]
    [ApiController]
    [Route("geral/horariotreino")]
    [ApiExplorerSettings(GroupName = "geral")]
    public class HorarioTreinoController : ControllerBase
    {
        private readonly IHorarioTreinoConta _horarioTreinoConta;

        public HorarioTreinoController(IHorarioTreinoConta horarioTreinoConta)
        {
            _horarioTreinoConta = horarioTreinoConta;
        }

        /// <summary>
        /// Busca o horário de treino para a conta a partir do ID informado.
        /// </summary>
        [HttpGet("buscarporconta/{idConta}")]
        [PermissaoUsuario(Entidade.HorarioTreino, Acao.Visualizar)]
        [ProducesResponseType(typeof(HorarioTreinoContaResponse), StatusCodes.Status200OK)]
        public IActionResult BuscarPorConta(int idConta)
        {
            try
            {
                var horarioTreino = _horarioTreinoConta.Buscar(idConta, HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, horarioTreino);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Atualiza um horário de treino para a conta com um usuário informado.
        /// </summary>
        [HttpPut("atualizar")]
        [PermissaoUsuario(Entidade.HorarioTreino, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Atualizar(AtualizarHorarioTreinoRequest request)
        {
            try
            {
                _horarioTreinoConta.Atualizar(request);
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
        [PermissaoUsuario(Entidade.HorarioTreino, Acao.Deletar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Deletar(int idHorarioTreino)
        {
            try
            {
                _horarioTreinoConta.Deletar(idHorarioTreino);
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
        [PermissaoUsuario(Entidade.HorarioTreino, Acao.Inserir)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirHorarioTreinoRequest request)
        {
            try
            {
                _horarioTreinoConta.Inserir(request);
                return StatusCode((int)HttpStatusCode.OK, "Horário de treino para a conta definido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Lista os horários de treino de conta para o usuário a partir do ID informado.
        /// </summary>
        [HttpGet("listarporusuario/{idUsuario}")]
        [PermissaoUsuario(Entidade.HorarioTreino, Acao.Visualizar)]
        [ProducesResponseType(typeof(List<HorarioTreinoUsuarioResponse>), StatusCodes.Status200OK)]
        public IActionResult ListarPorUsuario(int idUsuario)
        {
            try
            {
                var horarios = _horarioTreinoConta.ListarPorUsuario(idUsuario, HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, horarios);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Lista os horários de treino de conta para o usuário autenticado.
        /// </summary>
        [HttpGet("listarporusuariologado")]
        [ProducesResponseType(typeof(List<HorarioTreinoUsuarioResponse>), StatusCodes.Status200OK)]
        public IActionResult ListarPorUsarioLogado()
        {
            try
            {
                var horarios = _horarioTreinoConta.ListarPorUsuario(int.Parse(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_USUARIO)), 
                    HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));

                return StatusCode((int)HttpStatusCode.OK, horarios);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
