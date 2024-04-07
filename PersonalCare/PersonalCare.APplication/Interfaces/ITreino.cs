using PersonalCare.Application.Models.Requests.Treino;
using PersonalCare.Application.Models.Responses.Treino;

namespace PersonalCare.Application.Interfaces
{
    public interface ITreino
    {
        void Atualizar(AtualizarTreinoRequest request);
        TreinoResponse Buscar(int idTreino);
        void Deletar(int idTreino);
        void Inserir(InserirTreinoRequest request);
        List<TreinoResponse> Listar();
    }
}
