using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Treino
{
    public class AtualizarTreinoRequest : InserirTreinoRequest
    {
        [Obrigatorio]
        public int Id { get; set; }
    }
}
