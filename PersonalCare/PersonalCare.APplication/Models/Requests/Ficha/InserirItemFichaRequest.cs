using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class InserirItemFichaRequest : ItemFichaRequest
    {
        [Obrigatorio]
        public int IdFicha { get; set; }
    }
}
