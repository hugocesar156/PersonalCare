using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class InserirFichaRequest
    {
        public InserirFichaRequest()
        {
            ItemFicha = new List<ItemFichaRequest>();
        }

        [Obrigatorio, DataFutura]
        public DateTime DataValidade { get; set; }

        [Obrigatorio]
        public int IdConta { get; set; }

        [Obrigatorio]
        public List<ItemFichaRequest> ItemFicha { get; set; }
    }
}
