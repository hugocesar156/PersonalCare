namespace PersonalCare.Application.Services
{
    public class TemplateService
    {
        public static (string, string) TemplateRedefinicaoSenha(string nomeEmpresa)
        {
            var arquivo = "C:/Projetos/PersonalCare/PersonalCare/PersonalCare.Application/Templates/redefinicaoSenha.html";
            var template = File.ReadAllText(arquivo);

            var codigo = string.Empty;

            for (var i = 0; i < 5; i++)
            {
                codigo += new Random().Next(0, 9);
            }

            template = template.Replace("{{NOME_EMPRESA}}", nomeEmpresa);
            template = template.Replace("{{CODIGO_VERIFICACAO}}", codigo);

            return (template, codigo);
        }
    }
}
