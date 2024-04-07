using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface ITreinoRepository
    {
        bool Atualizar(Treino request);
        Treino? Buscar(int idTreino);
        bool Deletar(int idTreino);
        bool ExisteTreinoPorCategoria(int idCategoria);
        int Inserir(Treino request);
        List<Treino> Listar(int idCategoria = 0);
    }
}
