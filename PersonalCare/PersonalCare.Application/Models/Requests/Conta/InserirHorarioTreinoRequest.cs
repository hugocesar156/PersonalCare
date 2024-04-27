using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Conta
{
    public class InserirHorarioTreinoRequest : HorarioTreinoRequest
    {
        [Obrigatorio]
        public int IdConta { get; set; }
    }
}
