using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IHorarioTreinoContaRepository
    {
        bool Atualizar(HorarioContaTreino request);
        HorarioContaTreino? Buscar(int idConta);
        bool Inserir(HorarioContaTreino request);
        bool Deletar(int idHorarioTreino);
        HorarioContaTreino? VerificaDisponibilidade(int idConta);
        HorarioContaTreino? VerificaDisponibilidade(TimeSpan horaInicio, TimeSpan horaFim, int idUsuario);
    }
}
