using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IContaRepository
    {
        bool Atualizar(Conta request);
        bool AtualizarContato(ContatoConta request);
        bool AtualizarHorarioTreino(HorarioContaTreino request);
        Conta? Buscar(int idConta);
        (string cpf, string email) BuscarDadosExistentes(string cpf, string email, int idConta = 0);
        bool Deletar(int idConta);
        bool DeletarContato(int idContato);
        int Inserir(Conta request);
        bool InserirContato(ContatoConta request);
        bool InserirContato(List<ContatoConta> request);
        bool InserirHorarioTreino(HorarioContaTreino request);
        List<Conta> Listar();
        HorarioContaTreino? VerificaDisponibilidadeHorario(int idConta);
        HorarioContaTreino? VerificaDisponibilidadeHorario(TimeSpan horaInicio, TimeSpan horaFim, int idUsuario);
    }
}
