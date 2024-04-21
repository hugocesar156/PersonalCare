using PersonalCare.Domain.Entities;

namespace PersonalCare.Application.Services
{
    public class TemplateService
    {
        private const string DIRETORIO_ARQUIVOS = "C:/Projetos/PersonalCare/PersonalCare/PersonalCare.Application/Templates/";

        public static string TemplateFicha(Ficha ficha, string conta, string usuario, string nomeEmpresa)
        {
            var templateFicha = File.ReadAllText($"{DIRETORIO_ARQUIVOS}ficha.html");
            var templateGrupo = File.ReadAllText($"{DIRETORIO_ARQUIVOS}grupo.html");
            var templateItemGrupo = File.ReadAllText($"{DIRETORIO_ARQUIVOS}itemGrupo.html");

            templateFicha = templateFicha.Replace("{{NOME_EMPRESA}}", nomeEmpresa);
            templateFicha = templateFicha.Replace("{{USUARIO_FICHA}}", usuario);
            templateFicha = templateFicha.Replace("{{DATA_CRIACAO}}", ficha.DataCriacao.ToShortDateString());
            templateFicha = templateFicha.Replace("{{DATA_VENCIMENTO}}", ficha.DataValidade.ToShortDateString());
            templateFicha = templateFicha.Replace("{{NOME_CONTA}}", conta.Split(' ')[0]);

            var gruposFicha = ficha.ItemFicha.GroupBy(i => i.Grupo);

            var gruposTemplate = string.Empty;

            foreach (var grupo in gruposFicha)
            {
                var grupoHTML = templateGrupo;

                grupoHTML = grupoHTML.Replace("{{GRUPO}}", grupo.Key);

                var itensTemplate = string.Empty;

                foreach (var item in grupo)
                {
                    var itemHTML = templateItemGrupo;

                    itemHTML = itemHTML.Replace("{{TREINO}}", item.Treino.Nome);
                    itemHTML = itemHTML.Replace("{{CATEGORIA}}", item.Treino.Categoria.Nome);
                    itemHTML = itemHTML.Replace("{{SERIES}}", item.Series.ToString());
                    itemHTML = itemHTML.Replace("{{REPETICOES}}", item.Repeticoes.ToString());

                    itensTemplate += itemHTML;
                }

                grupoHTML = grupoHTML.Replace("{{ITEM_GRUPO}}", itensTemplate);
                gruposTemplate += grupoHTML;
            }

            templateFicha = templateFicha.Replace("{{GRUPOS}}", gruposTemplate);

            return templateFicha;
        }

        public static (string, string) TemplateRedefinicaoSenha(string nomeEmpresa)
        {
            var template = File.ReadAllText($"{DIRETORIO_ARQUIVOS}redefinicaoSenha.html");

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
