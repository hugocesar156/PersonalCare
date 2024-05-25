using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Conta;
using PersonalCare.Application.Models.Responses.Usuario;

namespace PersonalCare.Application.Interfaces
{
    public interface IConta
    {
        void AlterarSenha(AlterarSenhaRequest request, int idConta);
        void Atualizar(AtualizarContaRequest request);
        void AtualizarContato(AtualizarContaContatoRequest request);
        AutenticarResponse Autenticar(AutenticarRequest request);
        ContaResponse Buscar(int idConta);
        void Deletar(int idConta);
        void DeletarContato(int idContato);
        void Inserir(InserirContaRequest request, int idUsuario);
        void InserirContato(InserirContaContatoRequest request);
        List<ContaResponse> Listar();
    }
}
