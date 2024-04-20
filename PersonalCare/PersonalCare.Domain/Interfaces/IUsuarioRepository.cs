using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        bool AdicionarPermissoes(List<PermissaoUsuario> request);
        bool AlterarSenha(Usuario request);
        bool Atualizar(Usuario request);
        Usuario? Buscar(int idUsuario, string idEmpresa);
        Usuario? BuscarPorEmail(string email, string idEmpresa);
        int Cadastrar(Usuario request);
        bool Deletar(int idUsuario, string idEmpresa);
        bool EmailCadastrado(string email, string idEmpresa, int idUsuario = 0);
        List<Usuario> Listar(string idEmpresa);
        List<Permissao> ListarPermissoes();
        void RegistrarAcesso(int idUsuario);
        bool RemoverPermissoes(int idUsuario, List<int> permissoes);
    }
}
