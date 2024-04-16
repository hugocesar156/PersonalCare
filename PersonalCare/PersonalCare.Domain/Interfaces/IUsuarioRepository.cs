using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        bool AdicionarPermissoes(List<PermissaoUsuario> request);
        Usuario? Buscar(int idUsuario, string idEmpresa);
        Usuario? BuscarPorEmail(string email, string idEmpresa);
        int Cadastrar(Usuario request);
        bool EmailCadastrado(string email, string idEmpresa);
        List<PermissaoUsuario> ListarPermissoes(int idUsuario);
        bool RemoverPermissoes(List<int> permissoes);
    }
}
