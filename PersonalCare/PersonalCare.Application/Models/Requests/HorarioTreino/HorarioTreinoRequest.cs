using PersonalCare.Application.Validations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace PersonalCare.Application.Models.Requests.HorarioTreino
{
    public abstract class HorarioTreinoRequest
    {
        private string horaInicio;
        private string horaFim;

        private TimeSpan horaInicioTimeSpan;
        private TimeSpan horaFimTimeSpan;

        public HorarioTreinoRequest()
        {
            horaInicio = string.Empty;
            horaFim = string.Empty;
        }

        [Obrigatorio, Horario(nameof(HoraFim))]
        public string HoraInicio
        {
            get => horaInicio;
            set
            {
                horaInicio = value;

                if (Regex.IsMatch(horaInicio, @"^([01][0-9]|2[0-3]):([0-5][0-9])$"))
                    horaInicioTimeSpan = new TimeSpan(int.Parse(horaInicio.Split(':')[0]), int.Parse(horaInicio.Split(':')[1]), 0);
            }
        }

        [Obrigatorio]
        public string HoraFim
        {
            get => horaFim;
            set
            {
                horaFim = value;

                if (Regex.IsMatch(horaFim, @"^([01][0-9]|2[0-3]):([0-5][0-9])$"))
                    horaFimTimeSpan = new TimeSpan(int.Parse(horaFim.Split(':')[0]), int.Parse(horaFim.Split(':')[1]), 0);
            }
        }

        [Obrigatorio]
        public int IdUsuario { get; set; }

        [JsonIgnore]
        public TimeSpan HoraInicioTimeSpan { get => horaInicioTimeSpan; }

        [JsonIgnore]
        public TimeSpan HoraFimTimeSpan { get => horaFimTimeSpan; }
    }
}
