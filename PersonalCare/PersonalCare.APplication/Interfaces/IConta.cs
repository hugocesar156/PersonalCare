using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Responses.Conta;

namespace PersonalCare.Application.Interfaces
{
    public interface IConta
    {
        ContaResponse Inserir(ContaRequest request);
        List<ContaResponse> Listar();
    }
}
