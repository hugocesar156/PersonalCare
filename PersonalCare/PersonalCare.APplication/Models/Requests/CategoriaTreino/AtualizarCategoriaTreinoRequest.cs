using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.CategoriaTreino
{
    public class AtualizarCategoriaTreinoRequest
    {
        [Obrigatorio]
        public int Id { get; set; }

        [Obrigatorio, TamanhoMaximo(20)]
        public string Nome { get; set; }
    }
}
