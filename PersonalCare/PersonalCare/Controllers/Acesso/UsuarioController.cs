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
        /// Altera a senha do usuário autenticado.
        /// </summary>
        [HttpPut("alterarsenha")]
        [Authorize]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AlterarSenha(AlterarSenhaRequest request)
        {
            try
            {
                _usuario.AlterarSenha(request, 
                    int.Parse(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_USUARIO)), 
                    HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));

                return StatusCode((int)HttpStatusCode.OK, "Registro de usuário atualizado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Atualiza um registro de usuário.
        /// </summary>
        [HttpPut("atualizar")]
        [Authorize, PermissaoUsuario(Entidade.Usuario, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Atualizar(AtualizarUsuarioRequest request)
        {
            try
            {
                _usuario.Atualizar(request, HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, "Registro de usuário atualizado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
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
        [Authorize, PermissaoUsuario(Entidade.Usuario, Acao.Visualizar)]
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
        [Authorize, PermissaoUsuario(Entidade.Usuario, Acao.Inserir)]
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

        /// <summary>
        /// Deleta um registro de um usuário a partir do ID informado.
        /// </summary>
        [HttpDelete("deletar/{idUsuario}")]
        [Authorize, PermissaoUsuario(Entidade.Usuario, Acao.Deletar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Deletar(int idUsuario)
        {
            try
            {
                _usuario.Deletar(idUsuario, HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, "Registro de usuário deletado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Envia um email para redefinição de senha de usuário.
        /// </summary>
        [HttpPost("enviaremailredefinicaosenha")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult EnviarEmailRedefinicaoSenha(RedefinicaoSenhaRequest request)
        {
            try
            {
                _usuario.EnviarEmailRedefinicaoSenha(request);
                return StatusCode((int)HttpStatusCode.OK, "Verificação de redefinição de senha enviada ao email informado.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Retorna uma lista de usuários.
        /// </summary>
        [HttpGet("listar")]
        [Authorize, PermissaoUsuario(Entidade.Usuario, Acao.Visualizar)]
        [ProducesResponseType(typeof(List<ListarUsuarioResponse>), StatusCodes.Status200OK)]
        public IActionResult Listar()
        {
            try
            {
                var usuarios = _usuario.Listar(HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, usuarios);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Valida o código de verificação para alteração de senha de usuário, 
        /// após a validação é gerado um token de acesso para redefinição de senha com um prazo de 10 minutos.
        /// </summary>
        [HttpPost("validarcodigoverificacao")]
        [ProducesResponseType(typeof(ValidarCodigoResponse), StatusCodes.Status200OK)]
        public IActionResult ValidarCodigoVerificacao(ValidarCodigoRequest request)
        {
            try
            {
                var tokenRedefinicao = _usuario.ValidarCodigoVerificacao(request);
                return StatusCode((int)HttpStatusCode.OK, tokenRedefinicao);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
