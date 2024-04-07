using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface ICategoriaTreinoRepository
    {
        bool Atualizar(CategoriaTreino request);
        CategoriaTreino? Buscar(int idCategoriaTreino);
        bool Deletar(int idCategoriaTreino);
        int Inserir(CategoriaTreino request);
        List<CategoriaTreino> Listar();
    }
}
