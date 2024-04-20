using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Usuario;

namespace PersonalCare.Application.Interfaces
{
    public interface IUsuario
    {
        void AdicionarPermissoes(AdicionarPermissaoRequest request, string idEmpresa);
        void Atualizar(AtualizarUsuarioRequest request, string idEmpresa);
        AutenticarResponse Autenticar(AutenticarRequest request);
        UsuarioResponse Buscar(int idUsuario, string idEmpresa);
        void Cadastrar(CadastrarUsuarioRequest request, string idEmpresa);
        void Deletar(int idUsuario, string idEmpresa);
        List<ListarUsuarioResponse> Listar(string idEmpresa);
        List<PermissaoResponse> ListarPermissoes();
        void RemoverPermissoes(RemoverPermissaoRequest request, string idEmpresa);
    }
}
