using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;
using static PersonalCare.Shared.PersonalCareEnums;

namespace PersonalCare.Application.Permissoes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PermissaoUsuarioAttribute : Attribute, IAuthorizationFilter
    {
        private readonly Entidade _entidade;
        private readonly Acao _acao;

        public PermissaoUsuarioAttribute(Entidade entidade, Acao acao)
        {
            _entidade = entidade;
            _acao = acao;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var idUsuario = context.HttpContext.User.FindFirstValue(PersonalCareClaims.ID_USUARIO);
            var idEmpresa = context.HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA);
            var permissaoRota = new KeyValuePair<string, List<string>>();

            if (!string.IsNullOrEmpty(idUsuario) && !string.IsNullOrEmpty(idEmpresa))
            {
                var permissoes = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(context.HttpContext.User.FindFirstValue(PersonalCareClaims.PERMISSOES)) ?? new Dictionary<string, List<string>>();
                permissaoRota = permissoes.FirstOrDefault(p => p.Key == _entidade.ToString() && p.Value.Contains(_acao.ToString()));
            }

            if (permissaoRota.Value is null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new { Erro = "Erro ao processar requisição.", Mensagem = "Acesso negado para a rota." });
            }
        }
    }
}
