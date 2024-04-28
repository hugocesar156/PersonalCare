using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.HorarioTreino
{
    public class InserirHorarioTreinoRequest : HorarioTreinoRequest
    {
        [Obrigatorio]
        public int IdConta { get; set; }
    }
}
