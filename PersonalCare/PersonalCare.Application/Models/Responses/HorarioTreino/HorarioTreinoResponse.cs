namespace PersonalCare.Application.Models.Responses.HorarioTreino
{
    public class HorarioTreinoContaResponse
    {
        public HorarioTreinoContaResponse(int _id, TimeSpan _horaInicio, TimeSpan _horaFim, string _nomeConta, string _nomeUsuario)
        {
            Id = _id;
            HoraInicio = _horaInicio.ToString()[0..5];
            HoraFim = _horaFim.ToString()[0..5];
            NomeConta = _nomeConta;
            NomeUsuario = _nomeUsuario;
        }

        public int Id { get; }
        public string HoraInicio { get; }
        public string HoraFim { get; }
        public string NomeConta { get; }
        public string NomeUsuario { get; }
    }
}
