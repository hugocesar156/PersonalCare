using PersonalCare.Application.Models.Requests.CategoriaTreino;
using PersonalCare.Application.Models.Responses.CategoriaTreino;

namespace PersonalCare.Application.Interfaces
{
    public interface ICategoriaTreino
    {
        void Atualizar(AtualizarCategoriaTreinoRequest request);
        CategoriaTreinoResponse Buscar(int idCategoriaTreino);
        void Deletar(int idCategoriaTreino);
        void Inserir(InserirCategoriaTreinoRequest request);
        List<CategoriaTreinoResponse> Listar();
    }
}
