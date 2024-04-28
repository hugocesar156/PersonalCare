using PersonalCare.Domain.Entities;

namespace PersonalCare.Application.Models.Responses.HorarioTreino
{
    public class HorarioTreinoUsuarioResponse
    {
        public HorarioTreinoUsuarioResponse(int _id, TimeSpan _horaInicio, TimeSpan _horaFim, int _idConta, string _nomeConta, List<ContatoConta> _contatos)
        {
            Id = _id;
            HoraInicio = _horaInicio.ToString()[0..5];
            HoraFim = _horaFim.ToString()[0..5];
            IdConta = _idConta;
            NomeConta = _nomeConta;
            ContatoConta = _contatos.Select(c => c.Ddd + c.Numero).ToList();
        }

        public int Id { get; }
        public string HoraInicio { get; }
        public string HoraFim { get; }
        public int IdConta { get; }
        public string NomeConta { get; }
        public List<string> ContatoConta { get; }
    }
}
