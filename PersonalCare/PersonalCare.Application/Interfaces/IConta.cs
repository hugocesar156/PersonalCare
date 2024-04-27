using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Responses.Conta;

namespace PersonalCare.Application.Interfaces
{
    public interface IConta
    {
        void Atualizar(AtualizarContaRequest request);
        void AtualizarContato(AtualizarContaContatoRequest request);
        void AtualizarHorarioTreino(AtualizarHorarioTreinoRequest request);
        ContaResponse Buscar(int idConta);
        void Deletar(int idConta);
        void DeletarContato(int idContato);
        void Inserir(InserirContaRequest request, int idUsuario);
        void InserirContato(InserirContaContatoRequest request);
        void InserirHorarioTreino(InserirHorarioTreinoRequest request);
        List<ContaResponse> Listar();
    }
}
