using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Responses.Conta;

namespace PersonalCare.Application.Interfaces
{
    public interface IConta
    {
        ContaResponse Atualizar(AtualizarContaRequest request);
        ContaResponse Buscar(int idConta);
        void Deletar(int idConta);
        ContaResponse Inserir(InserirContaRequest request);
        List<ContaResponse> Listar();
    }
}
