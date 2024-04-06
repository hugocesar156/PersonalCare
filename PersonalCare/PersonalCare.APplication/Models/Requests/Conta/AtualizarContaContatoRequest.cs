using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.Conta
{
    public class AtualizarContaContatoRequest : ContaContatoRequest
    {
        [Obrigatorio]
        public int Id { get; set; }

        [Obrigatorio]
        public int IdConta { get; set; }
    }
}
