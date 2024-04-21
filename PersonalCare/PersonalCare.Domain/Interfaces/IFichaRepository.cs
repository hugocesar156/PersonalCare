using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IFichaRepository
    {
        bool Atualizar(Ficha request);
        bool AtualizarItemFicha(ItemFicha request);
        Ficha? Buscar(int idFicha);
        Ficha? BuscarPorConta(int idConta);
        bool Deletar(int idFicha);
        bool DeletarItemFicha(int idItemFicha);
        int Inserir(Ficha request);
        int InserirItemFicha(ItemFicha request);
    }
}
