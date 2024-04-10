using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IFichaRepository
    {
        Ficha? BuscarPorConta(int idConta);
        int Inserir(Ficha request);
        int InserirItemFicha(ItemFicha request);
    }
}
