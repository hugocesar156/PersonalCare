using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class AtualizarItemFichaRequest : ItemFichaRequest
    {
        [Obrigatorio]
        public int Id { get; set; }
    }
}
