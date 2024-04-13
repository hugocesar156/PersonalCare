using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class AtualizarFichaRequest
    {
        [Obrigatorio]
        public int Id { get; set; }

        [Obrigatorio, DataFutura]
        public DateTime DataValidade { get; set; }
    }
}
