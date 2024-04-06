using System.Net;

namespace PersonalCare.Shared
{
    public abstract class RequestError
    {
        public string Erro { get; }
        public string Mensagem { get; }
        public HttpStatusCode StatusCode { get; }
    }
}
