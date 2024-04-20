using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        EmailEmpresa? BuscarEmail(string idEmpresa);
    }
}
