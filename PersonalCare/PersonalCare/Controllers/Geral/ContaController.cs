using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Responses.Conta;
using PersonalCare.Application.Permissoes;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;
using static PersonalCare.Shared.PersonalCareEnums;

namespace PersonalCare.API.Controllers.Geral
{
    [Authorize]
    [ApiController]
    [Route("geral/conta")]
    [ApiExplorerSettings(GroupName = "geral")]
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
        [HttpPut("atualizar")]
        [Permissao(Entidade.Conta, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Atualizar(AtualizarContaRequest request)
        {
            try
            {
                _conta.Atualizar(request);
                return StatusCode((int)HttpStatusCode.OK, "Registro de conta atualizado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Atualiza um contato existente de um registro de conta.
        /// </summary>
        [HttpPut("atualizarcontato")]
        [Permissao(Entidade.Conta, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AtualizarContato(AtualizarContaContatoRequest request)
        {
            try
            {
                _conta.AtualizarContato(request);
                return StatusCode((int)HttpStatusCode.OK, "Contato da conta alterado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Atualiza um horário de treino para a conta com um usuário informado.
        /// </summary>
        [HttpPut("atualizarhorariotreino")]
        [Permissao(Entidade.Conta, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AtualizarHorarioTreino(AtualizarHorarioTreinoRequest request)
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
        /// Retorna registro de conta a partir do ID da conta informado.
        /// </summary>
        [HttpGet("buscar/{idConta}")]
        [Permissao(Entidade.Conta, Acao.Visualizar)]
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
        [HttpDelete("deletar/{idConta}")]
        [Permissao(Entidade.Conta, Acao.Deletar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
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
        /// Deleta um contato de um registro de conta a partir do ID do contato informado.
        /// </summary>
        [HttpDelete("deletarcontato/{idContato}")]
        [Permissao(Entidade.Conta, Acao.Deletar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult DeletarContato(int idContato)
        {
            try
            {
                _conta.DeletarContato(idContato);
                return StatusCode((int)HttpStatusCode.OK, "Contato da conta deletado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere um registro de conta.
        /// </summary>
        [HttpPost("inserir")]
        [Permissao(Entidade.Conta, Acao.Inserir)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirContaRequest request)
        {
            try
            {
                _conta.Inserir(request, int.Parse(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_USUARIO)));
                return StatusCode((int)HttpStatusCode.OK, "Registro de conta inserido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere um novo contato para o registro de conta.
        /// </summary>
        [HttpPost("inserircontato")]
        [Permissao(Entidade.Conta, Acao.Inserir)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult InserirContato(InserirContaContatoRequest request)
        {
            try
            {
                _conta.InserirContato(request);
                return StatusCode((int)HttpStatusCode.OK, "Contato adicionado para a conta com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere um horário de treino para a conta com um usuário informado.
        /// </summary>
        [HttpPost("inserirhorariotreino")]
        [Permissao(Entidade.Conta, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult InserirHorarioTreino(InserirHorarioTreinoRequest request)
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

        /// <summary>
        /// Retorna uma lista de contas.
        /// </summary>
        [HttpGet("listar")]
        [Permissao(Entidade.Conta, Acao.Visualizar)]
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
