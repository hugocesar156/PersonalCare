using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        int Cadastrar(Usuario request);
        bool EmailCadastrado(string email);
    }
}
