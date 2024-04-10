using PersonalCare.Application.Models.Requests.Ficha;

namespace PersonalCare.Application.Interfaces
{
    public interface IFicha
    {
        void Inserir(InserirFichaRequest request);
        void InserirItemFicha(InserirItemFichaRequest request);
    }
}
