using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;

namespace PersonalCare.Application.Permissoes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PermissaoContaAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var idConta = context.HttpContext.User.FindFirstValue(PersonalCareClaims.ID_CONTA);
            var idEmpresa = context.HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA);

            if (string.IsNullOrEmpty(idConta) || string.IsNullOrEmpty(idEmpresa))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new { Erro = "Erro ao processar requisição.", Mensagem = "Acesso negado para a rota." });
            }
        }
    }
}
