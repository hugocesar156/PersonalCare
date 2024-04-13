using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Conta
{
    public class AtualizarContaContatoRequest : ContaContatoRequest
    {
        [Obrigatorio]
        public int Id { get; set; }
    }
}
