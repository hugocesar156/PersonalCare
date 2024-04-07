using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Responses.Conta;

namespace PersonalCare.Application.Interfaces
{
    public interface IConta
    {
        void Atualizar(AtualizarContaRequest request);
        void AtualizarContato(AtualizarContaContatoRequest request);
        ContaResponse Buscar(int idConta);
        void Deletar(int idConta);
        void DeletarContato(int idContato);
        void Inserir(InserirContaRequest request);
        void InserirContato(InserirContaContatoRequest request);
        List<ContaResponse> Listar();
    }
}
