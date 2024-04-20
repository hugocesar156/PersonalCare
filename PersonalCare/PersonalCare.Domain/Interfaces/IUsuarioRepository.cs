using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        bool AdicionarPermissoes(List<PermissaoUsuario> request);
        bool Atualizar(Usuario request, string idEmpresa);
        Usuario? Buscar(int idUsuario, string idEmpresa);
        Usuario? BuscarPorEmail(string email, string idEmpresa);
        int Cadastrar(Usuario request);
        bool EmailCadastrado(string email, string idEmpresa, int idUsuario = 0);
        void RegistrarAcesso(int idUsuario);
        List<Usuario> Listar(string idEmpresa);
        List<Permissao> ListarPermissoes();
        bool RemoverPermissoes(int idUsuario, List<int> permissoes);
    }
}
