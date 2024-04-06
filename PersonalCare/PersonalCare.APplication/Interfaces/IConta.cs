using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Responses.Conta;

namespace PersonalCare.Application.Interfaces
{
    public interface IConta
    {
        ContaResponse Atualizar(AtualizarContaRequest request);
        void AtualizarContato(AtualizarContaContatoRequest request);
        ContaResponse Buscar(int idConta);
        void Deletar(int idConta);
        ContaResponse Inserir(InserirContaRequest request);
        void InserirContato(InserirContaContatoRequest request);
        List<ContaResponse> Listar();
    }
}
