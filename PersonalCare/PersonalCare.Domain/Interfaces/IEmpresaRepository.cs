using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        Empresa? Buscar(string idEmpresa);
    }
}
