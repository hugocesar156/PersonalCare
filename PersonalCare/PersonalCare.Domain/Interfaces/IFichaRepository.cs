using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IFichaRepository
    {
        bool AtualizarItemFicha(ItemFicha request);
        Ficha? BuscarPorConta(int idConta);
        bool DeletarItemFicha(int idItemFicha);
        int Inserir(Ficha request);
        int InserirItemFicha(ItemFicha request);
    }
}
