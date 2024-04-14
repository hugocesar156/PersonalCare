using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.CategoriaTreino
{
    public class InserirCategoriaTreinoRequest
    {
        [Obrigatorio, TamanhoMaximo(20)]
        public string Nome { get; set; }
    }
}
