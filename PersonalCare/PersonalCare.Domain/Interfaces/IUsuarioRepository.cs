using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? BuscarPorEmail(string email, string idEmpresa);
        int Cadastrar(Usuario request);
        bool EmailCadastrado(string email, string idEmpresa);
    }
}
