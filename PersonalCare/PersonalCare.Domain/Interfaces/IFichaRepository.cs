using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IFichaRepository
    {
        int Inserir(Ficha request);
    }
}
