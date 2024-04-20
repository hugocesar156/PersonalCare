namespace PersonalCare.Application.Services
{
    public class TemplateService
    {
        public static string TemplateRedefinicaoSenha(string nomeEmpresa, string codigoVerificacao)
        {
            var arquivo = "C:/Projetos/PersonalCare/PersonalCare/PersonalCare.Application/Templates/redefinicaoSenha.html";
            var template = File.ReadAllText(arquivo);

            template = template.Replace("{{NOME_EMPRESA}}", nomeEmpresa);
            template = template.Replace("{{CODIGO_VERIFICACAO}}", codigoVerificacao);

            return template;
        }
    }
}
