using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class AtualizarItemFichaRequest : ItemFichaRequest
    {
        [Obrigatorio]
        public int Id { get; set; }
    }
}
