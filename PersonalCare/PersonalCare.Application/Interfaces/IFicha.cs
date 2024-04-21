using PersonalCare.Application.Models.Requests.Ficha;
using PersonalCare.Application.Models.Responses.Ficha;

namespace PersonalCare.Application.Interfaces
{
    public interface IFicha
    {
        void Atualizar(AtualizarFichaRequest request);
        void AtualizarItemFicha(AtualizarItemFichaRequest request);
        FichaResponse BuscarFichaConta(int idConta);
        void Deletar(int idFicha);
        void DeletarItemFicha(int idItemFicha);
        void EnviarFichaPorEmail(int idFicha, string idEmpresa);
        void Inserir(InserirFichaRequest request, int idUsuario);
        void InserirItemFicha(InserirItemFichaRequest request);
    }
}
