using SelectPdf;
using System.Text.RegularExpressions;

namespace PersonalCare.Application.Services
{
    public class ConversorService
    {
        public static (string, byte[]) ConvertToPDF(string html, string nomeArquivo)
        {
            var documento = new HtmlToPdf().ConvertHtmlString(html);

            nomeArquivo = $"{Regex.Replace(nomeArquivo, "[\\/:*?\"<>|.]", "").Trim().Replace(" ", "_")}.pdf";

            documento.Save(nomeArquivo);
            documento.Close();

            var caminho = $"{Directory.GetCurrentDirectory()}\\{nomeArquivo}";

            if (File.Exists(caminho))
            {
                var bytes = File.ReadAllBytes(caminho);
                File.Delete(caminho);

                return (nomeArquivo, bytes);
            }

            throw new Exception("Erro durante conversão de arquvio.");
        }
    }
}
