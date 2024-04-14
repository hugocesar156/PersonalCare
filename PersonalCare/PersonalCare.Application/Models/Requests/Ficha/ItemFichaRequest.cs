using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class ItemFichaRequest
    {
        [Obrigatorio]
        public string Grupo { get; set; }

        [Obrigatorio]
        public byte Series { get; set; }

        [Obrigatorio]
        public byte Repeticoes { get; set; }

        [Obrigatorio]
        public int IdTreino { get; set; }
    }
}
