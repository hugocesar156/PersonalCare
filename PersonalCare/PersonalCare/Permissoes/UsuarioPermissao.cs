using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;

namespace PersonalCare.API.Permissoes
{
    public class UsuarioPermissao : Attribute, IAuthorizationFilter
    {
        private readonly Entidade _entidade;
        private readonly Acao _acao;

        public UsuarioPermissao(Entidade entidade, Acao acao)
        {
            _entidade = entidade;
            _acao = acao;
        }

        public enum Entidade
        {
            Conta,
            Ficha,
            CategoriaTreino,
            Treino
        }

        public enum Acao
        {
            Atualizar, 
            Deletar,
            Inserir,
            Visualizar
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var permissoes = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(context.HttpContext.User.FindFirstValue(PersonalCareClaims.PERMISSOES)) ?? new Dictionary<string, List<string>>();
            var permissaoRota = permissoes.FirstOrDefault(p => p.Key == _entidade.ToString() && p.Value.Contains(_acao.ToString()));
            
            if (permissaoRota.Value is null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new { Erro = "Erro ao processar requisição.", Mensagem = "Acesso negado para o usuário." });
            }
        }
    }
}
