using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.Treino
{
    public class InserirTreinoRequest
    {
        [Obrigatorio]
        public string Nome { get; set; }

        [Obrigatorio, TamanhoMaximo(100)]
        public string Descricao { get; set; }

        [Obrigatorio]
        public int IdCategoriaTreino { get; set; }
    }
}
