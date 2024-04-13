using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class InserirItemFichaRequest : ItemFichaRequest
    {
        [Obrigatorio]
        public int IdFicha { get; set; }
    }
}
