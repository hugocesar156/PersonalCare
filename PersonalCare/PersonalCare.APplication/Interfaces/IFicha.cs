using PersonalCare.Application.Models.Requests.Ficha;
using PersonalCare.Application.Models.Responses.Ficha;

namespace PersonalCare.Application.Interfaces
{
    public interface IFicha
    {
        void Atualizar(AtualizarFichaRequest request);
        void AtualizarItemFicha(AtualizarItemFichaRequest request);
        FichaResponse BuscarFichaConta(int idConta);
        void Inserir(InserirFichaRequest request);
        void InserirItemFicha(InserirItemFichaRequest request);
        void Deletar(int idFicha);
        void DeletarItemFicha(int idItemFicha);
    }
}
