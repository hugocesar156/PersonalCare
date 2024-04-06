using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.CategoriaTreino
{
    public class InserirCategoriaTreinoRequest
    {
        [Obrigatorio, TamanhoMaximo(20)]
        public string Nome { get; set; }
    }
}
