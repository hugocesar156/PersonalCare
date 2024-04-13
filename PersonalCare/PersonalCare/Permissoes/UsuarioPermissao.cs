using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace PersonalCare.API.Permissoes
{
    public class UsuarioPermissao : Attribute, IAuthorizationFilter
    {
        public UsuarioPermissao()
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claims = context.HttpContext.User.Claims;

            //Implementar permissões de rota
            if (false)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new { Erro = "Erro ao processar requisição.", Mensagem = "Acesso negado para o usuário." });
            }
        }
    }
}
