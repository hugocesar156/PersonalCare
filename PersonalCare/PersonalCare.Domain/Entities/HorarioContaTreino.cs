namespace PersonalCare.Domain.Entities
{
    public class HorarioContaTreino
    {
        public HorarioContaTreino(TimeSpan _horaInicio, TimeSpan _horaFim, int _idConta, int _idUsuario)
        {
            HoraInicio = _horaInicio;
            HoraFim = _horaFim;
            IdConta = _idConta;
            IdUsuario = _idUsuario;
            Conta = new Conta();
        }

        public HorarioContaTreino(int _id, TimeSpan _horaInicio, TimeSpan _horaFim, int _idUsuario)
        {
            Id = _id;
            HoraInicio = _horaInicio;
            HoraFim = _horaFim;
            IdUsuario = _idUsuario;
            Conta = new Conta();
        }

        public HorarioContaTreino(int _id, TimeSpan _horaInicio, TimeSpan _horaFim, int _idConta, int _idUsuario)
        {
            Id = _id;
            HoraInicio = _horaInicio;
            HoraFim = _horaFim;
            IdConta = _idConta;
            IdUsuario = _idUsuario;
            Conta = new Conta();
        }

        public HorarioContaTreino(int _id, TimeSpan _horaInicio, TimeSpan _horaFim, int _idConta, int _idUsuario, Conta _conta)
        {
            Id = _id;
            HoraInicio = _horaInicio;
            HoraFim = _horaFim;
            IdConta = _idConta;
            IdUsuario = _idUsuario;
            Conta = _conta;
        }

        public int Id { get; }
        public TimeSpan HoraInicio { get; }
        public TimeSpan HoraFim { get; }
        public int IdConta { get; }
        public int IdUsuario { get; }
        public Conta Conta { get; }
    }
}
