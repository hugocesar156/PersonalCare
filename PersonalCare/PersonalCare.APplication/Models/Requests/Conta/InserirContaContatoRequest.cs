using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Conta
{
    public class InserirContaContatoRequest : ContaContatoRequest
    {
        [Obrigatorio]
        public int IdConta { get; set; }
    }
}
