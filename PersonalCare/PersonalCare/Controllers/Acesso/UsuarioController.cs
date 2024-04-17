using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Usuario;
using PersonalCare.Application.Permissoes;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;
using static PersonalCare.Shared.PersonalCareEnums;

namespace PersonalCare.API.Controllers.Acesso
{
    [ApiController]
    [Route("acesso/usuario")]
    [ApiExplorerSettings(GroupName = "acesso")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Autentica um usuário.
        /// </summary>
        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarResponse), StatusCodes.Status200OK)]
        public IActionResult Autenticar(AutenticarRequest request)
        {
            try
            {
                var response = _usuario.Autenticar(request);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Busca um registro de usuário a partir do ID informado.
        /// </summary>
        [HttpGet("buscar/{idUsuario}")]
        [Authorize, Permissao(Entidade.Usuario, Acao.Visualizar)]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        public IActionResult Buscar(int idUsuario)
        {
            try
            {
                var usuario = _usuario.Buscar(idUsuario, HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, usuario);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Cadastra um usuário.
        /// </summary>
        [HttpPost("cadastrar")]
        [Authorize, Permissao(Entidade.Usuario, Acao.Inserir)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Cadastrar(CadastrarUsuarioRequest request)
        {
            try
            {
                _usuario.Cadastrar(request, HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, "Usuário cadastrado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
