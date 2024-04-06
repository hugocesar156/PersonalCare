using System.Net;

namespace PersonalCare.Shared
{
    public class PersonalCareException : Exception
    {
        public PersonalCareException(string _erro, string? _mensagem, HttpStatusCode _statusCode)
        {
            Erro = _erro;
            Mensagem = _mensagem ?? "Erro interno no servidor.";
            StatusCode = _statusCode;
        }

        public string Erro { get; }
        public string Mensagem { get; }
        public HttpStatusCode StatusCode { get; }
    }
}
